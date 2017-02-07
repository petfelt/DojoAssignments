class Animal(object):
    def __init__(self, name="billy", health=100):
        self.name = name
        self.health = health

    def walk(self):
        self.health -= 1
        return self

    def run(self):
        self.health -=5
        return self

    def displayHealth(self):
        print "Name:",str(self.name),"\nHealth:",str(self.health)
        return self

animal1 = Animal("animal", 100)
animal1.walk().walk().walk().run().run().displayHealth()

class Dog(Animal):
    def __init__(self, name="dog", health=150):
        self.name = "dog"
        self.health = 150

    def pet(self):
        self.health += 5
        return self

dog = Dog(animal1)
dog.walk().walk().walk().run().run().pet().displayHealth()

class Dragon(Animal):
    def __init__(self, name="dragon", health=170):
        self.name = "dragon"
        self.health = 170

    def fly(self):
        self.health += 10
        return self

    def displayHealth(self):
        print "This is a dragon!"
        print "Name:",str(self.name),"\nHealth:",str(self.health)
        return self

dragon = Dragon(animal1)
dragon.walk().walk().walk().run().run().fly().fly().displayHealth()

# Below code does not work: GOOD.
# animal1.fly().pet()
