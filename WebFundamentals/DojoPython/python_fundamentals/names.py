#Names
#Part I
students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]

def names_part1(students):
    for elements in students:
        names = elements.values()
        print("{} {}".format(names[0], names[1]))

print "\n"
names_part1(students)

#Part II
users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }
def names_part2(users):
    for key, data in users.items():
        print key
        i = 0
        for value in data:
            i += 1
            print i,"-",value["first_name"].upper(),value["last_name"].upper(),"-",len(value["first_name"]+value["last_name"])

print "\n"
names_part2(users)
print "\n"
