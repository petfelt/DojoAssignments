#Multiples:
#Part I:
print "\nOdd Numbers: 1 - 1000:"
for count in range(1,1000,2):
    print count
#Part II:
print "\nMultiples of Five: 5 - 1,000,000:"
for count in range(5,1000000,5):
    print count
#Sum List:
a = [1, 2, 5, 10, 255, 3]
print "\nSum of List "+str(a)+":"
sum = 0
for element in a:
    sum += element
print "Sum is "+str(sum)
#Assignment: Average List:
print "\nAverage of List "+str(a)+":"
avg = sum/len(a)
print "Avg is "+str(avg)+"\n"
