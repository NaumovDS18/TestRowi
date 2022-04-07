Feature: SpecFlowFeature1

@mytag
Scenario: 001_Search Rowi in Google
	Given Opened Google search
	When Input rowi in google searh bar
	Then First link in google contains rowi.com
	When Close browser

	@mytag
Scenario: 002_Search Rowi in Yandex
	Given Opened Yandex search
	When Input rowi in yandex searh bar
	Then First link in yandex contains rowi.com
	When Close browser