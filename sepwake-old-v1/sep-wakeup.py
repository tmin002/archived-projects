#!/usr/bin/python3
#-*- coding:utf-8 -*-

import os
import datetime

WAKEUP_TIME_HOUR = 23 
WAKEUP_TIME_MINUTE = 6 
TARGET_MAC_ADDR = "1c:6f:65:89:c5:17"
TARGET_IP_ADDR = "192.168.0.255"
LOOP_CNT = 0
#########################
#########################

def write(text,title="-",importance=0):
	print("[%s] %s" % (title,text))

def shell(text):
	os.system(text)

def nmin():
	return datetime.datetime.today().hour*60  + datetime.datetime.today().minute

def dmin():
	return WAKEUP_TIME_HOUR* 60 + WAKEUP_TIME_MINUTE

#########################
#########################

shell('clear')

print('S.E.P. (Self Enhancement Project) Manager')
print('written by ssh9930, wishing for successfully reaching the goal.')
print("This program is based on WOL/ALARM-WAKEUP feature, and iOS shortcut extension. only intended for myself.\n")
write("**WAKEUP SERVER VERSION**\n")

if(input("[?] Do you want to specify variables? (y/n)") == 'y'):
	a = input('[-] Enter Wakeuptime (00:00) :').split()
	WAKEUP_TIME_HOUR = int(a[0])
	WAKEUP_TIME_MINUTE = int(a[1])
	TARGET_MAC_ADDR = input('[-] Enter mac address :')
	TARGET_IP_ADDR = input('[-] Enter ip address (broadcast: 192.168.0.255 in this network environment):')

while True:
	write('#%d waking'%LOOP_CNT, '***')
	write('to escape, press ctrl+z')
	write('nmin,dmin=%d,%d'%(nmin(),dmin()))
	write('waiting for alarm...')

	while nmin()<dmin():
		shell('sleep 0.3')

	write('BINGO, sending magic packet to target.')
	shell('wakeonlan %s -i %s' % (TARGET_MAC_ADDR, TARGET_IP_ADDR))
	write('sent, waiting for day to pass..')

	while nmin()>0:
		shell('sleep 0.3')
