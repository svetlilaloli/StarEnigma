Regular expressions exercise
# Star Enigma
The war is in its peak, but you, young Padawan, can turn the tides with your programming skills. You are tasked to create a program to __decrypt__ the messages of The Order and prevent the death of hundreds of lives. <br/>
You will receive several messages, which are __encrypted__ using the legendary star enigma. You should __decrypt the messages__, following these rules:<br/>
To properly decrypt a message, you should __count all the letters [s, t, a, r] – case insensitive__ and __remove__ the count from the __current ASCII value of each symbol__ of the encrypted message.<br/>
After decryption:<br/>
Each message should have a __planet name, population, attack type ('A', as attack or 'D', as destruction) and soldier count__.<br/>
The planet name __starts after '@'__ and contains __only letters from the Latin alphabet__. <br/>
The planet population __starts after ':'__ and is an __Integer__;<br/>
The attack type may be __"A"(attack) or "D"(destruction)__ and must be __surrounded by "!"__ (exclamation mark).<br/>
The __soldier count__ starts after __"->"__ and should be an Integer.<br/>
The order in the message should be: __planet name -> planet population -> attack type -> soldier count__. Each part can be separated from the others by __any character except: '@', '-', '!', ':' and '>'__.<br/>
## Input / Constraints
* The __first line holds n__ – the number of __messages– integer in range [1…100]__;
* On the next __n__ lines, you will be receiving encrypted messages.
## Output
After decrypting all messages, you should print the decrypted information in the following format:<br/>
First print the attacked planets, then the destroyed planets.<br/>
__"Attacked planets: {attackedPlanetsCount}"__<br/>
__"-> {planetName}"__<br/>
__"Destroyed planets: {destroyedPlanetsCount}"__<br/>
__"-> {planetName}"__<br/>
The planets should be __ordered by name alphabetically__.
## Examples
__Input__       |	__Output__	    |   __Comments__
----------------|-------------------|-----------------
2|Attacked planets: 1|We receive two messages, to decrypt them we calculate the key: First message has decryption key 3. So we substract from each characters code 3.
STCDoghudd4=63333$D$0A53333|-> Alderaa|First message has decryption key 3. So we substract from each characters code 3. __PQ@Alderaa1:30000!A!->20000__
EHfsytsnhf?8555&I&2C9555SR| Destroyed planets: 1|The second message has key 5. __@Cantonica:3000!D!->4000NM__
 _| -> Cantonica|Both messages are valid and they contain planet, population, attack type and soldiers count. After decrypting all messages we print each planet according the format given.
3|Attacked planets: 0|We receive three messages. Message one is decrypted with key 4: __pp$##@Coruscant:2000000000!D!->5000__
tt(''DGsvywgerx>6444444444%H%1B9444|Destroyed planets: 2|Message two is decrypted with key 7: __@Jakku:200000!A!MMMM__ This is invalid message, missing soldier count, so we continue.
GQhrr\|A977777(H(TTTT|-> Cantonica|The third message has key 5. __@Cantonica:3000!D!->4000NM__
EHfsytsnhf?8555&I&2C9555SR|	-> Coruscant|
