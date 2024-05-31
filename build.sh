#!/bin/bash

set -xe

# first compile dotnet program to make folders
dotnet build

# build a static library
#gcc -c -o hello.o hello.c && ar rcs libhello.a hello.o
#rm hello.o

# build a shared library into dotnet compiled folder
gcc -shared -o ./bin/Debug/net8.0/libhello.so -fPIC hello.c

# run dotnet program
dotnet run
