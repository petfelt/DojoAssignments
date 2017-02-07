class MathDojo(object):
    def __init__(self, result=0):
        self.result=0

    def add(self, add1=5, add2=0, add3=0):
        if isinstance(add1, (list, tuple)):
            for element in add1:
                self.result+=element
        else:
            self.result += add1

        if isinstance(add2, (list, tuple)):
            for element in add2:
                self.result+=element
        else:
            self.result += add2

        if isinstance(add3, (list, tuple)):
            for element in add3:
                self.result+=element
        else:
            self.result += add3
        return self

    def subtract(self, sub1=5, sub2=5, sub3=0):
        if isinstance(sub1, (list, tuple)):
            temp = 0
            for element in sub1:
                temp+=element
            self.result -= temp
        else:
            self.result -= sub1

        if isinstance(sub2, (list, tuple)):
            temp = 0
            for element in sub2:
                temp+=element
            self.result-=temp
        else:
            self.result -= sub2

        if isinstance(sub3, (list, tuple)):
            temp = 0
            for element in sub3:
                temp+=element
            self.result-=temp
        else:
            self.result-=sub3
        return self



# Still works with new code.
md = MathDojo().add(2).add(2, 5).subtract(3, 2).result
print md

# Added tuple for test. Works.
md2 = MathDojo().add([1],3,4).add((3, 5, 7, 8), [2, 4.3, 1.25]).subtract(2, [2,3], [1.1, 2.3]).result
print md2
