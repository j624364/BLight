#!/bin/bash

dotnet build
if [ $? -eq 0 ]
then
	sudo ./bin/Debug/net6.0/BLight inc
fi
