#Stars Part I & Part II
def stars_num(arr):
    for element in arr:
        i = 0
        stars = ""
        if type(element) is int: # If it's an int...
            while i < element:
                stars += "*"
                i += 1
            print stars
        else: # Else, basically if it's a string...
            adder = element[0].lower()
            for c in element:
                stars += adder
            print stars




x = [4, 6, 1, 3, 5, 7, 25]
stars_num(x)
x = [4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"]
stars_num(x)
