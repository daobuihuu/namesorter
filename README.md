# Name Sorter
This program is built using .NET Core Console Application. Its purpose is loading person names from file then sort and export to text file with following details:

Given a set of names, order that set first by last name, then by any given names the person may have. A name must have at least 1 given name and may have up to 3 given names.

# Design
## Overview
The main features of the program are
1. Load names from text file
2. Sort by last name first then by given names both in ascending order (default)
3. Export names to text file

## Principals
Program is built following SOLID principals
- Single Responsibility: classes and functions focus on one main problem
- Open/Closed: use abstraction for importing/exporting features that can be changed with new implementations (like import/export from excel)
- Dependency Inversion: main features (import/export) depends on abstraction than concrete implementation

## Design Patterns

- Composite Pattern: export feature leverages composite pattern that can output to both console and text file
- Strategy Pattern: use delegate for person name comparer as a simple implementation of strategy pattern

Others
Fluent Interface: chaining main features using fluent interface (ImportData, SortData, ExportData)

## Third-Party & Built In Features
- Dependency Injection: using built in infrastructure of .NET Core
- Logging: using Serilog to log to text file