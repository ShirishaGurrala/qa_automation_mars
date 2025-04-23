# This is a feature file for skill page. 
# It contains test scenarios. We write test steps and test data for that scenario in plain english.

Feature: Skill Functionality

@mars @skill
Scenario Outline: Add a new skill
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I add a new skill '<skillValue>' and '<skilllLevelValue>'
Then New skill should be successfully created '<skillValue>'
Examples: 
| email            | password | skillValue | skilllLevelValue |
| ShirishaG.@g.com | 123456   | Manual Testing       | Beginner      |
| ShirishaG.@g.com | 123456   | longTextInputslongTextInputslongTextInputslongTextInputslongTextInputs       | Beginner      |


Scenario: Edit an existing skill
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I update an existing skill '<skillValue>' and '<skilllLevelValue>' and '<skillValueOne>'
Then The updated skill with modified data should be successfully updated '<skillValue>'
Examples: 
| email            | password | skillValue         | skilllLevelValue | skillValueOne       |
| ShirishaG.@g.com | 123456   | Automation Testing | Expert           | Exploratory Testing |

Scenario: Delete an existing skill
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I delete an existing skill
Then The existing skill should be successfully removed
Examples: 
| email            | password |
|ShirishaG.@g.com|123456|

Scenario: Verify adding same skill with different skill levels
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I add same skill with different skill levels '<skillValue>' and '<skilllLevelValue>' and '<skilllevelValuetwo>'
Then An error message Duplicated data should be shown 
Examples: 
| email            | password | skillValue | skilllLevelValue | skilllevelValuetwo |
| ShirishaG.@g.com | 123456   | Selenium       | Beginner      | Expert        |

Scenario: Attempt to add the same skill twice
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I add same skill twice with same skill level '<skillValue>' and '<skilllLevelValue>'
Then An error message skill is already exist in your skill list should be shown 
Examples: 
| email            | password | skillValue | skilllLevelValue |
| ShirishaG.@g.com | 123456   | Postman       | Beginner      |

Scenario: Try to add an empty skill
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I add an empty skill '<skillValue>' and '<skilllLevelValue>'
Then An error message Please enter skill and level should be shown 
Examples: 
| email            | password | skillValue | skilllLevelValue |
| ShirishaG.@g.com | 123456   |		""      | Choose Skill Level    |


Scenario: Try to add a skill without selecting level
Given I logged into mars application successfully '<email>' and '<password>' and navigated to Skills page
When I add a new skill '<skillValue>' and  empty skill level '<skilllLevelValue>'
Then An error message Please enter skill and level should be displayed 
Examples: 
| email            | password | skillValue | skilllLevelValue |
| ShirishaG.@g.com | 123456   |	Github		| Choose Skill Level    |

