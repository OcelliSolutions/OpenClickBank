# Open:ClickBank Builder

**Only for use while developing the OpenAPI specification.**

The primary purpose of this application is to generate a proper OpenAPI specification of the ClickBank APIs. This allows for fast updates and re-generation of the spec instead of manually editing the `open-clickbank.yaml` file. The output of this applications writes to the solution folder.

## Usage

Just build the application. The `swashbuckle.aspnetcore.cli` .NET tool is installed automatically on build to allow for the export of the OpenAPI spec to file. The paths are designed to write the output to the correct folders by using relative paths.

## Development Notes

The `open-clickbank.yaml` should never be manually updated. All changes should occur to the models, enums, filters, and controllers that when built should generate a specification with the expected features.

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request
