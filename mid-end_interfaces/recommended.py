#!/usr/bin/env python3
import sys
import random
import time

# random.seed(int(sys.argv[1]) + int(str(datetime.now())))
random.seed(time.time())
string = str(random.randint(0,44)) + " " + str(random.randint(0,44)) + " " + str(random.randint(0,44))

f = open("get.txt", "w")
f.write(string)
f.close()