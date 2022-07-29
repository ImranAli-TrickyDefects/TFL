Feature: TFL journeys

Scenario Outline: Verify valid journey
Given the user navigates to the TFL app
When the user provides valid "<From>" and "<To>"
Then a valid journey is planned for them
Examples: 
| From         | To            |
| Wembley      | Ealing        |
| Wembley      | Marylebone    |
| Kings Cross  | Ealing        |
| Paddington   | Oxford Street |
| Baker Street | Victoria      |  


Scenario Outline: Verify invalid journey errors
Given the user navigates to the TFL app
When the user provides valid "<From>" and "<To>"
Then a valid journey cannot be planned
Examples: 
| From | To   |
| fdjs | xyz  |
| 123  | xyz  |
| "££$ | &**^ |

Scenario Outline: Verify no input validation
Given the user navigates to the TFL app
When the user provides valid "<From>" and "<To>"
Then journey input validation messages appear
Examples: 
| From | To |
|      |    |  

Scenario Outline: Plan a journey based on arrival time
Given the user navigates to the TFL app
When the user provides valid "<From>" and "<To>" for arrival time
And changes the arrival time
Then a valid journey is planned for them
Examples: 
| From         | To            |
| Wembley      | Ealing        |

Scenario Outline: Edit journey
Given the user navigates to the TFL app
When the user provides valid "<From>" and "<To>"
Then a valid journey is planned for them
And the journey can be edited
Examples: 
| From         | To            |
| Wembley      | Ealing        |

Scenario Outline: Verify recent journeys
Given the user navigates to the TFL app
When the user provides valid "<From>" and "<To>"
Then a valid journey is planned for them
Then the recent journeys are displayed
Examples: 
| From         | To            |
| Wembley      | Ealing        |
| Wembley      | Marylebone    |
| Kings Cross  | Ealing        |
| Paddington   | Oxford Street |
| Baker Street | Victoria      |  
