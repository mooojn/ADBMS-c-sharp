from termcolor import colored
from colorama import init
import os

init()  # Enables color support in CMD

print(colored("Plese turn off Visual Studio before pushing new changes.", "red"))

msg = input(colored("Commit Message: ", "cyan"))

print(colored("Adding files...", "yellow"))
os.system("git add .")

print(colored(f"Committing with message: {msg}", "green"))
os.system(f'git commit -m "{msg}"')

print(colored("Pushing to origin/main...", "magenta"))
os.system("git push -u origin main")

print(colored("✅ Done!", "green"))
