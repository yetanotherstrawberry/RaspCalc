# RaspCalc
This application is a basic calculator written in MAUI using .NET 7.
It supports mobile and desktop platforms.

![Program image with number 6 typed in](/RaspCalc/Screenshots/Dark6.png)


## Functionality
### Operators
You can perform multiplication, division, subtraction and addition on any 2 numbers with high (decimal) precision.
It is possible to square and square root any number with standard (double) precision.

![Program image with number 6 typed in](/RaspCalc/Screenshots/Dark2times3.png)

### Themes
This app supports both light and dark modes. The calculator will change its colors depending on the system theme.

![Light theme](/RaspCalc/Screenshots/LightStart.png)

### Culture awareness
This project is culture-independent. It will use the decimal separator returned by the OS in the number fields and show it on the keyboard.

![Responsive design and error](/RaspCalc/Screenshots/DarkResponsiveError.png)

### Errors
The app will display pop-up alerts when an error (like division by 0) occurs.

### Responsive design
It is possible to resize the window. The fields and buttons will stretch to fill it.

## Unit tests
This solution contains xUnit project for testing. It works with VS built-in testing system.
