using System;

namespace rpg_encounter
{
    public class Encounter {
        public Encounter(Samurai samurai, Wizard wizard, Ninja ninja, Zombie zombie1, Zombie zombie2, Spider spider1)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| Your party of a ninja, a wizard, and a samurai enter a    |");
            Console.WriteLine("| dark forest...                                            |");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|        Suddenly, two zombies and a spider appear!         |");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|                     What will you do?                     |");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|  The names of your allies in your party:                  |");
            Console.WriteLine("|  - Wizard                                                 |");
            Console.WriteLine("|  - Ninja                                                  |");
            Console.WriteLine("|  - Samurai                                                |");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("|  Type 'HELP' at any time to repeat attack instructions.   |");
            Console.WriteLine("-------------------------------------------------------------");
            Random rand = new Random();
            bool myTurn = true;
            int endGame = 3;
            while(endGame > 2){
                while(myTurn == true){
                    Console.WriteLine("Your command:");
                    string InputLine = Console.ReadLine();
                    if(InputLine == "HELP" || InputLine == "help"){
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Type 'HELP' at any time to repeat attack instructions.   |");
                        Console.WriteLine("|                                                           |");
                        Console.WriteLine("|  - Type '[ally_name]', then '[attack_move]', and finally  |");
                        Console.WriteLine("|    '[enemy]' to attack, replacing each [] section with    |");
                        Console.WriteLine("|    the applicable text. Hopefully this will make sense    |");
                        Console.WriteLine("|    when you type it.                                      |");
                        Console.WriteLine("|                                                           |");
                        Console.WriteLine("|  - Type 'HELP allies' to show all ally_names.             |");
                        Console.WriteLine("|  - Type 'health' to show the health of all allies/enemies.|");
                        Console.WriteLine("|  - Type 'stats' to show full stats for all allies/enemies.|");
                        Console.WriteLine("|  - Entering your ally's name, move name, etc. will show   |");
                        Console.WriteLine("|    what your possible entries for the next step are, so   |");
                        Console.WriteLine("|    don't worry too much! You'll be helped through this.   |");
                        Console.WriteLine("|                                                           |");
                        Console.WriteLine("|  - Typing nothing and hitting enter will ask you to type  |");
                        Console.WriteLine("|    in a new command.                                      |");
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "HELP allies" || InputLine == "help allies" || InputLine == "allies" || InputLine == "Allies") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  The names of your allies in your party:                  |");
                        Console.WriteLine("|  - Wizard                                                 |");
                        Console.WriteLine("|  - Ninja                                                  |");
                        Console.WriteLine("|  - Samurai                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "Health" || InputLine == "health" || InputLine == "HEALTH" || InputLine == "HP" ||InputLine == "hp") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Health of all beings in the encounter:");
                        Console.WriteLine("|  - Wizard: {0}",wizard.health);
                        Console.WriteLine("|  - Ninja: {0}", ninja.health);
                        Console.WriteLine("|  - Samurai: {0}", samurai.health);
                        Console.WriteLine("|  - Zombie1: {0}", zombie1.health);
                        Console.WriteLine("|  - Zombie2: {0}", zombie2.health);
                        Console.WriteLine("|  - Spider1: {0}", spider1.health);
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "Stats" || InputLine == "stats" || InputLine == "STATS") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Stats of all beings in the encounter:");
                        Console.WriteLine("|  - {0}",wizard.ToString());
                        Console.WriteLine("|  - {0}",ninja.ToString());
                        Console.WriteLine("|  - {0}",samurai.ToString());
                        Console.WriteLine("|  - {0}",zombie1.ToString());
                        Console.WriteLine("|  - {0}",zombie2.ToString());
                        Console.WriteLine("|  - {0}",spider1.ToString());
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "Wizard" || InputLine == "wizard") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Moves the Wizard can do:                                 |");
                        Console.WriteLine("|  - Wizard Attack (basic attack, needs target)             |");
                        Console.WriteLine("|  - Heal (heals self, no target)                           |");
                        Console.WriteLine("|  - Fireball (Cast fireball, does 20-50 dmg, needs target) |");
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "Ninja" ||InputLine == "ninja") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Moves the Ninja can do:                                  |");
                        Console.WriteLine("|  - Ninja Attack (basic attack, needs target)              |");
                        Console.WriteLine("|  - Steal (basic attack + 10 hp to self, needs target)     |");
                        Console.WriteLine("|  - Run away (Hurts self 15 hp, no target)                 |");
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "Samurai" ||InputLine == "samurai") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Moves the Samurai can do:                                |");
                        Console.WriteLine("|  - Samurai Attack (basic attack, needs target)            |");
                        Console.WriteLine("|  - Death Blow (basic attack + instant kill for targets    |");
                        Console.WriteLine("|    below 50 hp, needs target)                             |");
                        Console.WriteLine("|  - Meditate (Heals self to full [200 hp], no target)      |");
                        Console.WriteLine("-------------------------------------------------------------");
                    } else if (InputLine == "Samurai Attack" ||InputLine == "samurai attack" ||InputLine == "samuraiattack") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Who do you want to attack?                               |");
                        Console.WriteLine("|  - Zombie1                                                |");
                        Console.WriteLine("|  - Zombie2                                                |");
                        Console.WriteLine("|  - Spider1                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                        InputLine = Console.ReadLine();
                        Console.WriteLine("Your command:");
                        if (InputLine == "Zombie2" ||InputLine == "zombie2"){
                            samurai.attack(zombie2);
                        } else if (InputLine == "Spider1" ||InputLine == "spider1"){
                            samurai.attack(spider1);
                        } else {
                            samurai.attack(zombie1);
                        }
                        myTurn = false;
                    } else if (InputLine == "Wizard Attack" ||InputLine == "wizard attack" ||InputLine == "wizardattack") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Who do you want to attack?                               |");
                        Console.WriteLine("|  - Zombie1                                                |");
                        Console.WriteLine("|  - Zombie2                                                |");
                        Console.WriteLine("|  - Spider1                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Your command:");                       
                        InputLine = Console.ReadLine();
                        if (InputLine == "Zombie2" ||InputLine == "zombie2"){
                            wizard.attack(zombie2);
                        } else if (InputLine == "Spider1" ||InputLine == "spider1"){
                            wizard.attack(spider1);
                        } else {
                            wizard.attack(zombie1);
                        }
                        myTurn = false;
                    } else if (InputLine == "Ninja Attack" ||InputLine == "ninja attack" ||InputLine == "ninjaattack") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Who do you want to attack?                               |");
                        Console.WriteLine("|  - Zombie1                                                |");
                        Console.WriteLine("|  - Zombie2                                                |");
                        Console.WriteLine("|  - Spider1                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Your command:");
                        InputLine = Console.ReadLine();
                        if (InputLine == "Zombie2" ||InputLine == "zombie2"){
                            ninja.attack(zombie2);
                        } else if (InputLine == "Spider1" ||InputLine == "spider1"){
                            ninja.attack(spider1);
                        } else {
                            ninja.attack(zombie1);
                        }
                        myTurn = false;
                    } else if (InputLine == "Heal" ||InputLine == "heal") {
                        wizard.heal();
                        myTurn = false;
                    } else if (InputLine == "Fireball" ||InputLine == "fireball") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Who do you want to cast a fireball on?                   |");
                        Console.WriteLine("|  - Zombie1                                                |");
                        Console.WriteLine("|  - Zombie2                                                |");
                        Console.WriteLine("|  - Spider1                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Your command:");
                        InputLine = Console.ReadLine();
                        if (InputLine == "Zombie2" ||InputLine == "zombie2"){
                            wizard.fireball(zombie2);
                        } else if (InputLine == "Spider1" ||InputLine == "spider1"){
                            wizard.fireball(spider1);
                        } else {
                            wizard.fireball(zombie1);
                        }
                        myTurn = false;
                    } else if (InputLine == "Steal" ||InputLine == "steal") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Who do you want to steal health from?                    |");
                        Console.WriteLine("|  - Zombie1                                                |");
                        Console.WriteLine("|  - Zombie2                                                |");
                        Console.WriteLine("|  - Spider1                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Your command:");
                        InputLine = Console.ReadLine();
                        if (InputLine == "Zombie2" ||InputLine == "zombie2"){
                            ninja.steal(zombie2);
                        } else if (InputLine == "Spider1" ||InputLine == "spider1"){
                            ninja.steal(spider1);
                        } else {
                            ninja.steal(zombie1);
                        }
                        myTurn = false;
                    } else if (InputLine == "Run Away" ||InputLine == "run away" ||InputLine == "Run away" ||InputLine == "runaway"){
                        ninja.get_Away();
                        myTurn = false;
                    } else if (InputLine == "Death Blow" ||InputLine == "death blow" ||InputLine == "Death blow" ||InputLine == "deathblow") {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|  Who do you want to deal a Death Blow to?                 |");
                        Console.WriteLine("|  - Zombie1                                                |");
                        Console.WriteLine("|  - Zombie2                                                |");
                        Console.WriteLine("|  - Spider1                                                |");
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("Your command:");
                        InputLine = Console.ReadLine();
                        if (InputLine == "Zombie2" ||InputLine == "zombie2"){
                            samurai.death_blow(zombie2);
                        } else if (InputLine == "Spider1" ||InputLine == "spider1"){
                            samurai.death_blow(spider1);
                        } else {
                            samurai.death_blow(zombie1);
                        }
                        myTurn = false;
                    } else if (InputLine == "Meditate" ||InputLine == "meditate"){
                        samurai.meditate();
                        myTurn = false;
                    } else {
                        Console.WriteLine("-------------------------------------------------------------");
                        Console.WriteLine("|     I do not recognize that command! Please try again.    |");
                        Console.WriteLine("-------------------------------------------------------------");
                    }
                }

                // Do evil turn here.
                // Selects an evil character, their target, and their move randomly.
                int evilChar = rand.Next(1,4); // 1 = zombie1, 2 = zombie2, 3 = spider1.
                int evilTarget = rand.Next(1,4); // 1 = Wizard, 2 = Ninja, 3 = Samurai.
                int evilMove = rand.Next(1,4); // 1 = basic attack, 2 = special attack1, 3 = special attack2.
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|                      The enemy attacks!                   |");
                // Then logic it out... definitely more efficient ways to do all this code but oh well.
                if(evilChar == 1) {
                    if(evilTarget ==1){
                        if(evilMove == 1){
                            zombie1.attack(wizard);
                        } else if (evilMove == 2){
                            zombie1.life_steal(wizard);
                        } else{
                            zombie1.chew(wizard);
                        }
                    } else if (evilTarget == 2){
                        if(evilMove == 1){
                            zombie1.attack(ninja);
                        } else if (evilMove == 2){
                            zombie1.life_steal(ninja);
                        } else{
                            zombie1.chew(ninja);
                        }
                    } else {
                        if(evilMove == 1){
                            zombie1.attack(samurai);
                        } else if (evilMove == 2){
                            zombie1.life_steal(samurai);
                        } else{
                            zombie1.chew(samurai);
                        }
                    }
                } else if (evilChar == 2){
                    if(evilTarget ==1){
                        if(evilMove == 1){
                            zombie2.attack(wizard);
                        } else if (evilMove == 2){
                            zombie2.life_steal(wizard);
                        } else{
                            zombie2.chew(wizard);
                        }
                    } else if (evilTarget == 2){
                        if(evilMove == 1){
                            zombie2.attack(ninja);
                        } else if (evilMove == 2){
                            zombie2.life_steal(ninja);
                        } else{
                            zombie2.chew(ninja);
                        }
                    } else {
                        if(evilMove == 1){
                            zombie2.attack(samurai);
                        } else if (evilMove == 2){
                            zombie2.life_steal(samurai);
                        } else{
                            zombie2.chew(samurai);
                        }
                    }
                } else {
                    if(evilTarget ==1){
                        if(evilMove == 1){
                            spider1.attack(wizard);
                        } else if (evilMove == 2){
                            spider1.intimidate(wizard);
                        } else{
                            spider1.bite(wizard);
                        }
                    } else if (evilTarget == 2){
                        if(evilMove == 1){
                            spider1.attack(ninja);
                        } else if (evilMove == 2){
                            spider1.intimidate(ninja);
                        } else{
                            spider1.bite(ninja);
                        }
                    } else {
                        if(evilMove == 1){
                            spider1.attack(samurai);
                        } else if (evilMove == 2){
                            spider1.intimidate(samurai);
                        } else{
                            spider1.bite(samurai);
                        }
                    }
                }
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|                        Your Turn:                         |");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("|  The names of your allies in your party:                  |");
                Console.WriteLine("|  - Wizard                                                 |");
                Console.WriteLine("|  - Ninja                                                  |");
                Console.WriteLine("|  - Samurai                                                |");
                Console.WriteLine("-------------------------------------------------------------");
                myTurn = true;
                if(samurai.health <= 0 && wizard.health <= 0 && ninja.health <= 0){
                    endGame = -1;
                } else if(zombie1.health <= 0 && zombie2.health <= 0 && spider1.health <= 0){
                    endGame = 1;
                }
            }


            if (endGame < 0) {
                Console.WriteLine("\n\n-------------------------------------------------------------");
                Console.WriteLine("|                       Sorry, you lost!                    |");
                Console.WriteLine("|                                                           |");
                Console.WriteLine("|               Reset the program to try again.             |");
                Console.WriteLine("-------------------------------------------------------------\n");
            } else {
                Console.WriteLine("\n\n-------------------------------------------------------------");
                Console.WriteLine("|                  You won! Congratulations!                |");
                Console.WriteLine("|                                                           |");
                Console.WriteLine("|               Reset the program to try again.             |");
                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }
    }

}