# 📊 StockApp Basic (Learning)

A foundational stock market application built with C# that provides real-time stock data through an intuitive interface. Perfect for developers learning financial application development and API integration.

[![.NET](https://img.shields.io/badge/.NET-Framework-blue)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)
[![API](https://img.shields.io/badge/API-Finnhub-orange)](https://finnhub.io/)

---

## ✨ Features

- 🔍 **Stock Symbol Search** - Quick lookup of stock symbols with autocomplete
- 📈 **Real-Time Market Data** - Live stock prices, volume, and market changes
- 📊 **Price History** - View historical stock performance
- 🖥️ **Clean Interface** - Intuitive design focused on user experience
- ⚡ **Fast Performance** - Optimized API calls and data caching
- 🧩 **Extensible Architecture** - Modular design for easy feature additions

---

## 🛠️ Tech Stack

| Component | Technology |
|-----------|------------|
| **Language** | C# |
| **Framework** | .NET Framework |
| **API** | Finnhub Stock API |
| **IDE** | Visual Studio |
| **Architecture** | MVVM Pattern |

---

## 📁 Project Structure

```
StockApp_Basic/
├── 📁 FinnHubStock/          # API service layer
│   ├── Services/             # API integration services
│   ├── Models/               # Data models for API responses
│   └── Helpers/              # API utility functions
├── 📁 StockApp/              # Main application
│   ├── Views/                # UI components and forms
│   ├── ViewModels/           # Business logic layer
│   ├── Models/               # Application data models
│   └── Resources/            # Images, styles, and assets
├── 📁 StockVendor/           # Vendor abstractions
│   ├── Interfaces/           # API contracts
│   └── Implementations/      # Vendor-specific logic
├── 📄 StockApp.sln           # Visual Studio solution
├── 📄 .gitignore             # Git ignore rules
└── 📄 README.md              # This file
```

---

## 🚀 Quick Start

### Prerequisites

- [Visual Studio 2019+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET Framework 4.7.2+](https://dotnet.microsoft.com/download/dotnet-framework)
- [Finnhub API Key](https://finnhub.io/) (free tier available)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/abxba-dev/StockApp_Basic.git
   cd StockApp_Basic
   ```

2. **Open in Visual Studio**
   ```bash
   start StockApp.sln
   ```

3. **Configure API Key**
   
   Create or update `appsettings.json` in the main project:
   ```json
   {
     "FinnhubSettings": {
       "ApiKey": "YOUR_API_KEY_HERE",
       "BaseUrl": "https://finnhub.io/api/v1/"
     }
   }
   ```

4. **Build and Run**
   - Press `F5` in Visual Studio, or
   - Use the command line:
     ```bash
     dotnet build
     dotnet run
     ```

---

## 💡 Usage

### Basic Stock Lookup

1. **Launch the application**
2. **Enter a stock symbol** (e.g., `AAPL`, `MSFT`, `GOOGL`)
3. **Click Search** or press Enter
4. **View results** including:
   - Current price
   - Daily change and percentage
   - Trading volume
   - Market status

### Example Stock Symbols

| Symbol | Company |
|--------|---------|
| AAPL | Apple Inc. |
| MSFT | Microsoft Corporation |
| GOOGL | Alphabet Inc. |
| TSLA | Tesla, Inc. |
| AMZN | Amazon.com Inc. |

---

## 🔧 Configuration

### API Settings

The application uses Finnhub's free tier which provides:
- ✅ Real-time US stock prices
- ✅ 60 API calls per minute
- ✅ Company profiles and news

For production use, consider upgrading to a paid plan for higher rate limits.

---

## 🔄 API Integration

The application integrates with Finnhub API endpoints:

- **Quote**: `/quote` - Real-time stock prices
- **Profile**: `/stock/profile2` - Company information
- **Symbol Search**: `/search` - Stock symbol lookup

Rate limiting and error handling are implemented to ensure reliable operation.

---


## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
