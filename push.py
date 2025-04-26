import os

msg = input("Commit Message: ")

os.system("git add .")  
os.system(f'git commit -m "{msg}"')  
os.system("git push -u origin main")