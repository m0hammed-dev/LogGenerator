## Data Generation

Before you begin, run the program to generate a simulated log file.

1.  run `Program.cs` once.
2.  This will produce a file named `server_logs.txt` (approx. 500MB).
3.  **Note:** You can adjust `FileSizeInMB` if you want to test with larger datasets (e.g., 5GB+).

## Task

Create a separate class (or a new c# console app) that reads `server_logs.txt` and performs the analysis.

### Requirements

1. **Output:** Print the Top 5 IP addresses and their occurrence count.

2. **Memory Efficiency:** Able to handle large files (10GB+) efficiently.

3. **Performance:** Utilize the CPU efficiently.

4. **Correctness:** Ensure your counting logic is thread-safe.

### Format of `server_logs.txt`

Each line follows this standard format: `timestamp=1678886400;ip=192.168.1.5;duration=120ms;path=/api/v1/user`

### Evaluation Criteria

We will evaluate your submission based on:

- **Deep .NET Knowledge:** Efficient use of Streams, File I/O, and Data Structures.

- **Concurrency:** How you handle thread safety (locking, concurrent collections, or partitioning).

- **Code Quality:** Cleanliness, error handling, and separation of concerns.


### Deliverables

- The C# source code for your solution (e.g. link to public GitHub repo).


- **Design Rationale:** A brief technical summary covering some of the following points:

  - **Approach:** How did you tackle the concurrency and memory constraints?

  - **Selection:** Why did you choose these specific data structures and threading models?

  - **Trade-offs:** What are the upsides and downsides of your specific implementation?

  - **Alternatives:** What other approaches did you consider, and why did you decide against them?

---

Good Luck.
