Feature: Login Functionality
  As a user, I want to log in to the application to access restricted content.

  Background: 	
    Given I am on the application main page, click on sign in to navigate to login page
   
   Scenario: Perform a successful login
    When I enter valid credentials '<email>' and '<password>'
    Then I should see the profile page
    Examples: 
    | email            | password |
    |ShirishaG.@g.com|123456|

   Scenario: Fail login with invalid email
    When I enter an invalid email and valid password '<email>' and '<password>'
    Then I should see an error message
   Examples: 
    | email            | password |
    | ShirishaG1.@g.com | 123456   |

   Scenario: Fail login with invalid password
    When I enter a valid email and invalid password '<email>' and '<password>'
    Then I should see an error message
   Examples: 
    | email            | password |
    | ShirishaG.@g.com | 1234567   |

