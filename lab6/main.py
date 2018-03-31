#!/usr/bin/env python3

from sys import argv, exit

class Pixel:
	def __init__(self):
		self.__mDict = {"r": 0, "g": 0, "b":0}

	def getRed(self):
		return self.__mDict["r"]

	def getGreen(self):
		return self.__mDict["g"]

	def getBlue(self):
		return self.__mDict["b"]

	def setRed(self, r):
		self.__mDict["r"] = r

	def setBlue(self, b):
		self.__mDict["b"] = b

	def setGreen(self, g):
		self.__mDict["g"] = g

def main():
	if len(argv) < 4:
		print("Usage: ./main.py <input_file> <output_file> <mode>")
		return 1
	
	return 0


if __name__ == "__main__":
	exit(main())
