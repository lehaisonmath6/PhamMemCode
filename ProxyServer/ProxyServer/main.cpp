// myproxy.cpp : Defines the entry point for the console application.
// Author: Like Zhang
// Email: lzhang@cs.utsa.edu
// 12/05/2007


#include<WinSock2.h>
#include<WS2tcpip.h>
#include<wsipv6ok.h>
#include<stdio.h>
#include<queue>
#include <process.h>
#include <iostream>
#include "httprequestparser.h"
#define SPACE_CHAR  ' '
#define DEFAULT_PORT "8889"
#define DEFAULT_BUFLEN 1024

#pragma comment(lib,"Ws2_32.lib")



//#ifndef _WIN32_WINNT		// Allow use of features specific to Windows XP or later.                   
//#define _WIN32_WINNT 0x0501
//#endif
#define SPACE_CHAR  ' '
#define PROXY_PORT  6666
#define RESPONSE_BUFFER_SIZE 8192
#define MAX_THREADS		50


std::queue<SOCKET> socketBuffer;
HANDLE queueMutex;
HANDLE threadSymaphore;

SYSTEM_INFO sysInfo;

int GetHTML(const char* host,const char* port, const char *sendbuf, std::string &response, int& reslen) {
	response = "";
	reslen = 0;
	WSADATA wsaData;
	SOCKET ConnectSocket = INVALID_SOCKET;
	struct addrinfo *result = NULL,
		*ptr = NULL,
		hints;

	std::string senddata = "GET / HTTP/1.1\r\nHost: " + std::string(host) + "\r\nConnection: close\r\n\r\n";
	char recvbuf[DEFAULT_BUFLEN];
	int iResult;
	int recvbuflen = DEFAULT_BUFLEN;


	// Validate the parameters

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		printf("WSAStartup failed with error: %d\n", iResult);
		return 1;
	}

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_UNSPEC;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	// Resolve the server address and port
	iResult = getaddrinfo(host, port, &hints, &result);
	if (iResult != 0) {
		printf("getaddrinfo failed with error: %d\n", iResult);
		WSACleanup();
		return 1;
	}

	// Attempt to connect to an address until one succeeds
	for (ptr = result; ptr != NULL; ptr = ptr->ai_next) {

		// Create a SOCKET for connecting to server
		ConnectSocket = socket(ptr->ai_family, ptr->ai_socktype,
			ptr->ai_protocol);
		if (ConnectSocket == INVALID_SOCKET) {
			printf("socket failed with error: %ld\n", WSAGetLastError());
			WSACleanup();
			return 1;
		}

		// Connect to server.
		iResult = connect(ConnectSocket, ptr->ai_addr, (int)ptr->ai_addrlen);
		if (iResult == SOCKET_ERROR) {
			closesocket(ConnectSocket);
			ConnectSocket = INVALID_SOCKET;
			continue;
		}
		break;
	}

	freeaddrinfo(result);

	if (ConnectSocket == INVALID_SOCKET) {
		printf("Unable to connect to server!\n");
		WSACleanup();
		return 1;
	}

	// Send an initial buffer
	iResult = send(ConnectSocket, senddata.c_str(), senddata.length(), 0);
	if (iResult == SOCKET_ERROR) {
		printf("send failed with error: %d\n", WSAGetLastError());
		closesocket(ConnectSocket);
		WSACleanup();
		return 1;
	}

	printf("Bytes Sent: %ld\n", iResult);

	// shutdown the connection since no more data will be sent
	iResult = shutdown(ConnectSocket, SD_SEND);
	if (iResult == SOCKET_ERROR) {
		printf("shutdown failed with error: %d\n", WSAGetLastError());
		closesocket(ConnectSocket);
		WSACleanup();
		return 1;
	}

	// Receive until the peer closes the connection
	do {

		iResult = recv(ConnectSocket, recvbuf, recvbuflen, 0);
		if (iResult > 0)
		{
			//printf("Bytes received: %d\n", iResult);
			response += std::string(recvbuf);
			reslen += iResult;
		}

		else if (iResult == 0)
			printf("Connection closed\n");
		else
			printf("recv failed with error: %d\n", WSAGetLastError());

	} while (iResult > 0);
	//std::cout << response.c_str() << std::endl;
	// cleanup
	closesocket(ConnectSocket);
	WSACleanup();

	return 0;
}
void GetTarget(const char* request, std::string& host, std::string& port)
{
	host = "";
	port = "";

	//skip the first HTTP command
	while (*request != ' ')
	{
		++request;
	}
	//skip space
	while ((*request<'a' || *request>'z') && (*request<'A' || *request>'Z'))
		++request;
	const char* urlStart = request;

	if ((*request == 'H' || *request == 'h')
		&& (*request == 'T' || *request == 't')
		&& (*request == 'T' || *request == 't')
		&& (*request == 'P' || *request == 'p')
		&& (*request == ':')
		)
	{
		while (SPACE_CHAR == *request)
			++request;

		while (SPACE_CHAR != *request && ':' != *request && '\0' != *request && '\r' != *request && '\n' != *request)
		{
			host += *request;
			++request;
		}
		if (':' == *request)
		{
			while (SPACE_CHAR != *request && ':' != *request && '\0' != *request && '\r' != *request && '\n' != *request)
			{
				port += *request;
				++request;
			}
		}
		if (port.length() == 0)
			port = "80";

		return;
	}

	while (*request != '\0')
	{
		//Process "Host: "
		if (*request == '\n' && *(request + 1) == 'H' && *(request + 2) == 'o' && *(request + 3) == 's' && *(request + 4) == 't' && *(request + 5) == ':')
		{
			request += 6;

			while ((*request<'a' || *request>'z') && (*request<'A' || *request>'Z'))
				++request;
			//find host address in "Host: "
			while (*request != SPACE_CHAR && *request != '\t' && *request != '\r' && *request != '\n' && *request != '\0' && *request != ':')
			{
				host += *request;
				++request;
			}
			//find port number in "Host: "
			if (*request == ':')
			{
				while (*request != SPACE_CHAR && *request != '\t' && *request != '\r' && *request != '\n' && *request != '\0')
				{
					port += *request;
					++request;
				}
			}
			break;
		}
		++request;
	}

	if (host.length() > 0 && port.length() == 0)
	{
		while (SPACE_CHAR != *urlStart)
		{
			if (':' == *urlStart)
			{
				++urlStart;
				while (SPACE_CHAR != *urlStart && '/' != *urlStart && '\\' != *urlStart)
					port += *urlStart++;
				break;
			}
			++urlStart;
		}

		if (port.length() == 0)
			port = "80";


		return;
	}

}



unsigned __stdcall ClientSession(void *data) {
	SOCKET client_socket = (SOCKET)data;
	char recvbuf[DEFAULT_BUFLEN];
	int iResult, iSendResult;
	int recvbuflen = DEFAULT_BUFLEN;

	//Receive until the peer shuts down the connection
	do {

		iResult = recv(client_socket, recvbuf, recvbuflen, 0);
		if (iResult > 0) {
			printf("Bytes received: %d\n", iResult);

			std::string host, port, sendbuf;
			recvbuf[iResult] = 0;
			sendbuf = std::string(recvbuf);
			
			std::string response;
			int reslen;
			GetTarget(recvbuf, host, port);
			/*std::cout << "host : " << host << std::endl;
			std::cout << "port : " << port << std::endl;*/
			if (port == "80") {
				std::cout << sendbuf.c_str() << std::endl;
				//GetHTML(host.c_str(), port.c_str(), sendbuf.c_str(), response, reslen);
				//send(client_socket,response.c_str(), response.length(), 0);
				break;
				//std::cout << responsedata << std::endl;
			}
			
		}
		else if (iResult == 0)
			printf("Connection closing...\n");
		else {
			printf("recv failed: %d\n", WSAGetLastError());
			closesocket(client_socket);
			WSACleanup();
			return 1;
		}

	} while (iResult > 0);
	closesocket(client_socket);
	return 1;
}

void RunServer()
{
	WSAData wsaData;
	int iResult;
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		printf("WSAStartup failed: %d\n", iResult);
		return;
	}

	struct addrinfo *result = NULL, *ptr = NULL, hints;

	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;

	// Resolve the local address and port to be used by the server
	iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
	if (iResult != 0) {
		printf("getaddrinfo failed: %d\n", iResult);
		WSACleanup();
		return;
	}
	SOCKET serverSock = INVALID_SOCKET, ioSock = INVALID_SOCKET;
	serverSock = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	if (serverSock == INVALID_SOCKET) {
		printf("Error at socket(): %ld\n", WSAGetLastError());
		freeaddrinfo(result);
		WSACleanup();
		return;
	}

	// Setup the TCP listening socket
	iResult = bind(serverSock, result->ai_addr, (int)result->ai_addrlen);
	if (iResult == SOCKET_ERROR) {
		printf("bind failed with error: %d\n", WSAGetLastError());
		freeaddrinfo(result);
		closesocket(serverSock);
		WSACleanup();
		return;
	}

	printf("start proxy server on 127.0.0.1:%s", DEFAULT_PORT);
	if (listen(serverSock, SOMAXCONN) == SOCKET_ERROR) {
		printf("Listen failed with error: %ld\n", WSAGetLastError());
		closesocket(serverSock);
		WSACleanup();
		return;
	}

	while (true)
	{
		ioSock = accept(serverSock, NULL, NULL);
		if (ioSock == INVALID_SOCKET) {
			printf("accept failed: %d\n", WSAGetLastError());
			closesocket(ioSock);
			//WSACleanup();
			continue;
		}
		unsigned threadID;
		HANDLE hThread = (HANDLE)_beginthreadex(NULL, 0, &ClientSession, (void*)ioSock, 0, &threadID);
	}
	shutdown(serverSock, 2);
	closesocket(serverSock);
	WSACleanup();
}

int main(int argc, char** argv)
{
	GetSystemInfo(&sysInfo);

	printf("Demo HTTP Proxy Server ver 1.0");
	printf("Developed by: lehaisonmath6");

	RunServer();
	httpparser::Request request;
	
	system("pause");
	return 0;
}

