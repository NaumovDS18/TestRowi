Feature: SpecFlowFeature1

@mytag
Scenario Outline: Search Rowi
	Given Opened <SearchEngine>
	When Input rowi in <SearchBar> search bar
	Then First link in <Response> contains rowi.com
	When Close browser
Examples: 
| SearchEngine | SearchBar | Response |
| Google       | Google    | Google   |
| Yandex       | Yandex    | Yandex   |