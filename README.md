# Perfect Numbers - C# Implementation

A C# console application that finds and analyzes perfect numbers using various algorithms and optimization techniques.

## What are Perfect Numbers?

A perfect number is a positive integer that is equal to the sum of its proper positive divisors (divisors excluding the number itself). For example:
- **6** is a perfect number because its divisors are 1, 2, and 3, and 1 + 2 + 3 = 6
- **28** is a perfect number because its divisors are 1, 2, 4, 7, and 14, and 1 + 2 + 4 + 7 + 14 = 28

## Features

- **Perfect Number Detection**: Determine if a given number is perfect
- **Perfect Number Generation**: Find all perfect numbers up to a specified limit
- **Multiple Algorithms**: Compare different approaches for finding perfect numbers
- **Performance Analysis**: Measure and compare execution times
- **Euclid-Euler Theorem Implementation**: Generate perfect numbers using the mathematical formula
- **Interactive Console Interface**: User-friendly command-line interface

## Getting Started

### Prerequisites

- .NET 6.0 or later
- Visual Studio 2022 or Visual Studio Code (optional)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/james-tiger/PerfectNumbers_CHARP.git
cd PerfectNumbers_CHARP
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run
```

## Usage

### Command Line Interface

The application provides several options:

```
Perfect Numbers Calculator
==========================
1. Check if a number is perfect
2. Find all perfect numbers up to limit
3. Generate perfect numbers using Euclid-Euler theorem
4. Performance comparison
5. Exit

Enter your choice (1-5):
```

### Examples

#### Check if a number is perfect:
```
Enter a number to check: 28
28 is a perfect number!
Divisors: 1, 2, 4, 7, 14
Sum of divisors: 1 + 2 + 4 + 7 + 14 = 28
```

#### Find perfect numbers up to a limit:
```
Enter the upper limit: 10000
Perfect numbers found: 6, 28, 496, 8128
Time taken: 0.45 seconds
```

## Algorithms Implemented

### 1. Brute Force Method
- Checks all numbers from 1 to n
- For each number, finds all divisors and calculates their sum
- Time complexity: O(n²)

### 2. Optimized Divisor Finding
- Only checks divisors up to √n
- Significantly faster for large numbers
- Time complexity: O(n√n)

### 3. Euclid-Euler Theorem
- Uses the formula: 2^(p-1) × (2^p - 1) where (2^p - 1) is prime
- Generates perfect numbers using Mersenne primes
- Most efficient for generating known perfect numbers

## Project Structure

```
PerfectNumbers_CHARP/
├── src/
│   ├── Program.cs              # Main application entry point
│   ├── PerfectNumberChecker.cs # Core perfect number logic
│   ├── AlgorithmComparison.cs  # Performance comparison utilities
│   ├── MersennePrimes.cs       # Mersenne prime calculations
│   └── UserInterface.cs        # Console interface handling
├── tests/
│   ├── PerfectNumberTests.cs   # Unit tests
│   └── AlgorithmTests.cs       # Algorithm validation tests
├── docs/
│   └── mathematical-background.md
├── README.md
└── PerfectNumbers.csproj
```

## Mathematical Background

Perfect numbers have fascinated mathematicians for centuries:

- **Euclid** (around 300 BCE) proved that if 2^p - 1 is prime, then 2^(p-1) × (2^p - 1) is perfect
- **Euler** proved that all even perfect numbers have this form
- The first few perfect numbers are: 6, 28, 496, 8128, 33550336, 8589869056, ...
- It's unknown whether odd perfect numbers exist

## Performance Benchmarks

| Algorithm | Limit | Time (seconds) | Numbers Found |
|-----------|-------|----------------|---------------|
| Brute Force | 10,000 | 2.34 | 4 |
| Optimized | 10,000 | 0.45 | 4 |
| Euclid-Euler | 10,000 | 0.01 | 4 |

## Testing

Run the unit tests using:

```bash
dotnet test
```

The test suite includes:
- Validation of known perfect numbers
- Edge case testing
- Algorithm correctness verification
- Performance regression tests

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## Future Enhancements

- [ ] GUI implementation using WPF or WinForms
- [ ] Multi-threading for parallel processing
- [ ] Export results to CSV/JSON
- [ ] Web API for perfect number calculations
- [ ] Integration with mathematical libraries
- [ ] Support for arbitrary precision arithmetic

## References

- [Perfect Numbers - Wikipedia](https://en.wikipedia.org/wiki/Perfect_number)
- [Mersenne Primes - GIMPS](https://www.mersenne.org/)
- [Euclid-Euler Theorem](https://en.wikipedia.org/wiki/Euclid%E2%80%93Euler_theorem)

## Author

**James Tiger**
- GitHub: [@james-tiger](https://github.com/james-tiger)

## Acknowledgments

- Thanks to the mathematical community for centuries of research on perfect numbers
- Inspired by classical algorithms and modern optimization techniques
- Special thanks to contributors and testers

---

*"Perfect numbers like perfect men are very rare." - René Descartes*
