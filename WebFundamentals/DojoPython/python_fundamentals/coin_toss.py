import random


#Coin Toss simulation.
def coin_toss():
    heads = 0
    tails = 0
    for element in range(1,5001):
        if round(random.random()) == 1:
            heads += 1
            print "Attempt #"+str(element)+": Throwing a coin... It's a head! ... Got "+str(heads)+" head(s) so far and "+str(tails)+" tail(s) so far."
        else:
            tails += 1
            print "Attempt #"+str(element)+": Throwing a coin... It's a tail! ... Got "+str(heads)+" head(s) so far and "+str(tails)+" tail(s) so far."
    print "Ending the program, thank you!"

coin_toss()
