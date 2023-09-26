--- Chain of responsiblity. ---

Sender --> Handler --> Receiver

sender :-  Invokes the Handler.
Handler :- Runs through the chain of 
			receivers.
Receiver :- Handles the given command.
Decouple your code and achieve a cleaner, more extensible code base.
An object oriented way to express a chain of “if”, “else if” and “else” 
statements.

