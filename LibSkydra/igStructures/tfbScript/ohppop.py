import os

# Define the directory to search in (current directory)
directory = os.getcwd()

# Function to replace 'igObject' with 'igNamedObject' in a given file
def replace_in_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        content = file.read()

    # Check if the file contains the string "public class Op"
    if "public class Op" in content:
        # Replace 'igObject' with 'igNamedObject'
        new_content = content.replace('igObject', 'igNamedObject')
        
        # Write the changes back to the file only if changes were made
        if new_content != content:
            with open(file_path, 'w', encoding='utf-8') as file:
                file.write(new_content)
            print(f'Replaced in: {file_path}')

# Walk through the directory
for root, _, files in os.walk(directory):
    for filename in files:
        if filename.endswith('.cs'):
            file_path = os.path.join(root, filename)
            replace_in_file(file_path)
