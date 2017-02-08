class Car(object):
    def __init__(self, price=5000, speed="35mph", fuel="Full", mileage="105mpg"):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        self.tax = 0.12
        if self.price > 10000:
            self.tax = 0.15
    def display_all(self):
        print "\nPrice: "+str(self.price)+"\nSpeed: "+str(self.speed)+"\nFuel: "+str(self.fuel)+"\nMileage: "+self.mileage+"\nTax: "+str(self.tax)


car1 = Car(2000, "35mph", "Full", "55mpg")
car2 = Car(15000, "70mph", "Full", "105mpg")
car3 = Car(5000, "45mph", "Not Full", "60mpg")
car4 = Car(6500, "55mph", "Kind of Full", "78mpg")
car5 = Car(20000, "100mph", "Half Full", "200mpg")
car6 = Car(100, "15mph", "Empty", "45mpg")
car1.display_all()
car2.display_all()
car3.display_all()
car4.display_all()
car5.display_all()
car6.display_all()
print("\nAll displayed! Goodbye!\n")
