class Underscore(object):
    def map(self, arr, callback):
        return map(callback, arr)
    def reduce(self, arr, callback):
        return reduce((callback),arr)
    def find(self, arr, callback):
        for element in arr:
            if callback(element):
                return element
        return None
        return find(callback, arr)
    def filter(self, arr, callback):
        return filter(callback, arr)
    def reject(self, arr, callback):
        lister = []
        for element in arr:
            if not callback(element):
                lister.append(element)
        return lister
# you just created a library with 5 methods!
# let's create an instance of our class
_ = Underscore() # yes we are setting our instance to a variable that is an underscore
mapper = _.map([1, 2, 3, 4, 5, 6], lambda x: x % 2 == 0)
print mapper
summer = _.reduce([1, 2, 3], lambda x, y: x * y)
print summer
finder = _.find([1, 2, 3, 4, 5, 6], lambda x: x % 2 == 0)
print finder
evens = _.filter([1, 2, 3, 4, 5, 6], lambda x: x % 2 == 0)
print evens
odds = _.reject([1, 2, 3, 4, 5, 6], lambda x: x % 2 == 0)
print odds
# should return [2, 4, 6] after you finish implementing the code above
