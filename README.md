APPLICATION:

Pizza companies spend a lot of man hours on phones taking orders when they could be delivering pizzas, baking pizzas, or cleaning dishes.  This program would be a first step towards automating this system in a faked intelligent way to alleviate man hours on the company.  This will allow for faster responses and a more cost efficient company.

OVERVIEW:

The program is written in C#.  The grammar is located in SpeechApplication\bin\Release\PizzaOrder.xml.  The program was compiled and tested using Visual C# 2010 Express.

The program welcomes the consumer and asks how it may help them.  The program is designed to work solely with speech between the program and the consumer, although there is a console write out reiterating the computers speech for debugging purposes.  The consumer can respond naturally and order a pizza, by either including all of the information (size and toppings) or leaving one or both out.  The program then asks for the required information, reviews the order and asks if it correct, then includes the cost of the order.  If the program does not understand the information correctly, it will restart the interaction from the beginning minus the welcome.  Currently there is no record of the order, but the information is being extracted and could be sent to an ordering system.

The “natural” interaction is simulated not by artificial intelligence, but an expansive grammar which uses context and popular sayings around pizza ordering to fake intelligence.  Most speech programs are very rigid in order to limit the expected responses.  This is less rigid and may make errors in understanding, but because of the feedback loop to determine if the order was taken correctly, the user should be able to at least correct errors.  This grammar style creates a natural flow as if talking to a person instead of a stop and go style of most automated phone systems.


DESIGN NOTES:

•	The program prompts the consumer by saying “Thank you for choosing Steven’s Pizza Delivery System.  The system requires politeness. You can leave at any time by saying exit. How can I help you?”

•	The consumer then responds, either in a way that gives the system the size and all of the toppings or giving one or neither.  The consumer is flexible in how much information he/she can give to the program and how it is given.

•	The politeness requirement allows for the user to list numerous toppings allowing the program to understand when the user is finished by looking for please at the end of the sentence.

•	The program then seeks to identify the other variables necessary to complete the pizza order.

•	The program reviews the order and asks for confirmation.  If the order is confirmed the program will give the price of the order and claim that it is entered into the system, although there is currently no system to enter the order into.

•	The user can exit the application at any time by the verbal command ‘exit’. This option at all points during execution of the program to provide the user with maximum flexibility. This is an example of the convenience provided by grammars.

•	The grammar used in the application is called ‘PizzaOrder.xml.’  It provides a large amount of flexibility for ordering pizza.