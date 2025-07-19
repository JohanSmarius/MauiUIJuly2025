# Instructions for MAUI Application Using MVVM

1. **Project Setup**
    - Create a new .NET MAUI application.
    - Add necessary NuGet packages for MVVM (e.g., `CommunityToolkit.Mvvm`).
    - Add necesaary NuGet packages the the Syncfusion .net maui open source library

2. **Folder Structure**
    - Organize your project into `Models`, `Views`, and `ViewModels` folders.

3. **Model Creation**
    - Define your data models in the `Models` folder.

4. **ViewModel Implementation**
    - Create ViewModel classes in the `ViewModels` folder.
    - Use `ObservableObject` and `RelayCommand` from MVVM toolkit for property change notifications and commands.

5. **View Binding**
    - Set the `BindingContext` of each View to its corresponding ViewModel.
    - Use data binding in XAML to connect UI elements to ViewModel properties and commands.
    - Use compiled binding to bind the viewmodel

6. **Navigation**
    - Implement navigation logic in ViewModels using MVVM-friendly patterns.

7. **Testing**
    - Write unit tests for ViewModels to ensure logic is separated from UI.

8. **Best Practices**
    - Avoid code-behind logic in Views.
    - Keep ViewModels free of UI dependencies.

9. This application is meant for a first medical aid charity to maintain the events they help at. Every event has a begin and end moment. This can be at a different day. An event happens at a certain address for an certain client. For the event volunteers are needed. Volunteers can only be booking by 2, so no uneven numbers are allowed. Once an event is entered it is in the requested state. An event can be split up into shifts. For every shift the number of requested volunteers are needed. Per shift the volunteers must be assigned. Upon creation of an event, the event is in the requested state. If volunteers for all shifts have been assigned, the state should become confirmed. 

Refer to the official MAUI and MVVM documentation for detailed examples.