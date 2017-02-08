import unittest
from underscore import Underscore

class UnderscoreTest(unittest.TestCase):
    def setUp(self):
        # create an instance of the Underscore module we created
        self._ = Underscore()
        # initialize a list to run our tests on
        self.test_list = [1,2,3,4,5]
        self.result = self._.map(self.test_list, lambda x: x % 2 == 0)
        self.result2 = self._.reduce(self.test_list, lambda x, y: x * y, 0)
        self.result3 = self._.find(self.test_list, lambda x: x % 2 == 0)
        self.result4 = self._.filter(self.test_list, lambda x: x % 2 == 0)
        self.result5 = self._.reject(self.test_list, lambda x: x % 2 == 0)

    def testMap(self):
        return self.assertEqual([False, True, False, True, False], self.result)
    def testReduce(self):
        return self.assertEqual(0, self.result2)
    def testFind(self):
        return self.assertEqual(False, self.result3)
    def testFilter(self):
        return self.assertEqual([False, False, False], self.result4)
    def testReject(self):
        return self.assertEqual([True, True], self.result5)

if __name__ == "__main__":
    unittest.main()
