from random import randint

#Scores & Grades:
def scores_grades():
    print "Scores and Grades"
    for element in range(0,10):
        random_num = randint(60,100)
        letter_grade = "D"
        if(70<=random_num <= 79):
            letter_grade = "C"
        elif(80<=random_num <= 89):
            letter_grade = "B"
        elif(90<=random_num <= 100):
            letter_grade = "A"
        print "Score: "+str(random_num)+"; Your grade is "+letter_grade
    print "End of the program. Bye!"


scores_grades()
