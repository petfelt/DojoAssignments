#Odd/Even:
def odd_even():
    for element in range(1,2001):
        if(element % 2 ==0):
            print "Number is "+str(element)+".   This is an even number."
        else:
            print "Number is "+str(element)+".   This is an odd number."

odd_even()

#Multiply:
def multiply(old_list, multiplier):
    new_list = []
    for i in old_list:
        new_list.append(i * multiplier)
    return new_list

a = [2,4,10,16]
print "\nOriginal list: "+str(a)
b = multiply(a, 5)
print "Multiplied by five: "+str(b)

#Layered Multiply:
def layered_multiples(arr):
  new_array = []
  for element in arr:
      temp = []
      i = 0
      while i < element:
          temp.append(1)
          i += 1
      new_array.append(temp)
  return new_array

x = layered_multiples(multiply([2,4,5],3))
print "\nLayered List: "+str(x)+"\n"
# output should be:
# [[1,1,1,1,1,1],[1,1,1,1,1,1,1,1,1,1,1,1],[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1]]
