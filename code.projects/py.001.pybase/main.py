from src.Options.MenuOptions import MenuOptions

class MainApp:
    @staticmethod
    def start():
        app = MenuOptions()
        app.run()

if __name__ == "__main__":
    MainApp.start()