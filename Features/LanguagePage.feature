# This is a feature file for language page. 
# It contains test scenarios. We write test steps and test data for that scenario in plain english.

Feature: Language Functionality

@mars @language
Scenario Outline: Add a new language
Given I logged into mars application successfully '<email>' and '<password>'
When I add a new language '<languageValue>' and '<levelValue>'
Then New language should be successfully created '<languageValue>'
Examples: 
| email            | password | languageValue | levelValue |
| ShirishaG.@g.com | 123456   | Marati       | Fluent      |
| ShirishaG.@g.com | 123456   | longTextInputslongTextInputslongTextInputslongTextInputslongTextInputs       | Fluent      |


Scenario: Edit an existing language
Given I logged into mars application successfully '<email>' and '<password>'
When I update an existing language '<languageValue>' and '<levelValue>'
Then The updated language with modified data should be successfully updated '<languageValue>'
Examples: 
| email            | password | languageValue | levelValue |
| ShirishaG.@g.com | 123456   | Spanish       | Basic      |

Scenario: Delete an existing language
Given I logged into mars application successfully '<email>' and '<password>'
When I delete an existing language
Then The existing language should be successfully removed
Examples: 
| email            | password |
|ShirishaG.@g.com|123456|

Scenario: Verify adding same language with different lauguage levels
Given I logged into mars application successfully '<email>' and '<password>'
When I add same language with different language levels '<languageValue>' and '<levelValue>' and '<levelValuetwo>'
Then An error message should be shown 
Examples: 
| email            | password | languageValue | levelValue | levelValuetwo |
| ShirishaG.@g.com | 123456   | English       | Basic      | Fluent        |

Scenario: Attempt to add the same language twice
Given I logged into mars application successfully '<email>' and '<password>'
When I add same language twice with same language level '<languageValue>' and '<levelValue>'
Then An error message language is already exist in your language list should be shown 
Examples: 
| email            | password | languageValue | levelValue |
| ShirishaG.@g.com | 123456   | English       | Basic      |

Scenario: Try to add an empty language
Given I logged into mars application successfully '<email>' and '<password>'
When I add an empty language '<languageValue>' and '<levelValue>'
Then An error message Please enter language and level should be shown 
Examples: 
| email            | password | languageValue | levelValue |
| ShirishaG.@g.com | 123456   |		""      | Choose Language Level    |


Scenario: Try to add a language without selecting language level
Given I logged into mars application successfully '<email>' and '<password>'
When I add a new language '<languageValue>' and  empty language level '<levelValue>'
Then An error message Please enter language and level should be displayed 
Examples: 
| email            | password | languageValue | levelValue |
| ShirishaG.@g.com | 123456   |	English		| Choose Language Level    |

Scenario: Try to add more than four languages
Given I logged into mars application successfully '<email>' and '<password>'
When I add four languages '<languageValue>' and  '<levelValue>'
Then I should not add fifth language
Examples: 
| email            | password | languageValue | levelValue |
| ShirishaG.@g.com | 123456   | English       | Fluent     |

