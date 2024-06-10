﻿Feature: FinServResult

As a user
I want to browse the LexisNexis website
So that I can read the list of Financial Services home products

@tag1
Scenario: Verify Financial Services Result
    Given User opens the home page
    Then I verify the following on Home Page:
      | Financial Services           |
      | Insurance                    |
      | Life and Pensions            |
      | Corporations and Non-Profits |
    When I expand Choose your industry accordion
    And I click Financial Services
    Then I verify the following on Financial page:
      | Financial Crime Compliance      |
      | Customer Data Management        |
      | Collections and Recovery        |
      | Risk Orchestration              |
      | Fraud and Identity Management   |
      | Credit Risk Assessment          |
      | Investigations and Due Diligence|