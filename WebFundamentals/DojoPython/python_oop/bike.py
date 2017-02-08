class Bike(object):
    # Attributes & methods here
    def __init__(self, price=100, max_speed="10mph", miles = 0):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0
        # print "This bike was passed:",str(self.price),str(self.max_speed),str(miles)

    def displayInfo(self):
        print "Price: "+str(self.price)+"\nMaximum speed: "+str(self.max_speed)+"\nMiles: "+str(self.miles)
        return self
    def ride(self):
        self.miles += 10
        print "Riding..."
        return self
    def reverse(self):
        self.miles -= 5
        if self.miles < 0:
            self.miles = 0
        print "Reversing..."
        return self

bike1 = Bike(200,"25mph",10)
bike1.ride().ride().ride().reverse().displayInfo()
bike2 = Bike(210,"20mph",15)
bike2.ride().ride().reverse().reverse().displayInfo()
bike3 = Bike(250,"30mph",7)
bike3.reverse().reverse().reverse().displayInfo()
