import re
def get_matching_words(regex):
 words = ["aimlessness", "assassin","regularexpression", "baby", "beekeeper", "belladonna", "cannonball", "crybaby", "denver", "embraceable", "facetious", "flashbulb", "gaslight", "hobgoblin", "iconoclast", "issue", "kebab", "kilo", "laundered", "mattress", "millennia", "natural", "obsessive", "paranoia", "queen", "rabble", "reabsorb", "sacrilegious", "schoolroom", "tabby", "tabloid", "unbearable", "union", "videotape"]
 matches = []
 for word in words:
 	if re.search(regex,word):
 		matches.append(word)
 return matches

#1
matches_1 = get_matching_words(r".v")
print "\n1. "+str(matches_1)
#2
matches_2 = get_matching_words(r".ss")
print "2. "+str(matches_2)
#3
matches_3 = get_matching_words(r"e$")
print "3. "+str(matches_3)
#4
matches_4 = get_matching_words(r"b.b")
print "4. "+str(matches_4)
#5
matches_5 = get_matching_words(r"b.+b")
print "5. "+str(matches_5)
#6
matches_6 = get_matching_words(r"b.*b")
print "6. "+str(matches_6)
#7
matches_7 = get_matching_words(r"a.*e.*i.*o.*u")
print "7. "+str(matches_7)
#8
matches_8 = get_matching_words(r"^[regulaxprsion]+$") 
print "8. "+str(matches_8)
#9
matches_9 = get_matching_words(r"(.)\1")
print "9. "+str(matches_9)+"\n"
