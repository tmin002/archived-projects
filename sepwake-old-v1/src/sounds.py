#!/usr/bin/python3
#-*- coding:utf-8 -*-
import os
import time
import datetime
import threading
import requests
import json

from src.base import *

def play(file):
	#shell("mpg321 -q '%s'"%file) - linux
	shell("afplay '%s'"%file)

def playwav(file):
	#shell("aplay -q '%s'"%file) - linux
	shell("afplay '%s'"%file)
