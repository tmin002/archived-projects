#!/bin/bash

clear
echo "sepwakev2 script"
echo "[build and debug start point]"
dotnet run
echo "[done. return for repeat, ctrl+C for exit] ?"
read
./build.sh
