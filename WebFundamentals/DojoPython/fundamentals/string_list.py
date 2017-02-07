
# Find and replace Activity.
print "\nFind & Replace Activity:"
st = "If monkeys like bananas, then I must be a monkey!"
print "Places found 'monkey': "+str(st.find('monkeys'))+", "+str(st.find('monkey'))
new_st = st.replace('monkey','alligator')
print new_st

#Min and Max Activity.
print "\nMin & Max Activity:"
x = [2,54,-2,7,12,98]
print "List: "+str(x)
print "Max of this list: "+str(max(x))
print "Min of this list: "+str(min(x))


#First and Last Activity.
print "\nFirst & Last Activity:"
y = ["hello",2,54,-2,7,12,98,"world"]
print "List: "+str(y)
print "First: "+str(y[0:1])
print "Last: "+str(y[len(y)-1:len(y)])
new_y = []
new_y.append(y[0])
new_y.append(y[len(y)-1])
print "New List: "+str(new_y)

#New List Activity.
print "\nNew List Activity:"
z = [19,2,54,-2,7,12,98,32,10,-3,6]
print "List: "+str(z)
z.sort()
new_z = []
while(z[0] < 0):
    new_z.append(z.pop(0))
print "New List: "+str(new_z)
z.insert(0,new_z)
print "Original List Modified: "+str(z)+"\n"
