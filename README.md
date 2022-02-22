# Tokenage Tic Tac Toe

## How to install

## Github

### During Development
While developing, good practices are:

- Keep your upstream updated with the most recent code from local (at the very least, daily pushes).

- This also involves rebasing your local branch often (never merge downstream, only rebase).

- Send multiple - but meaningful commits.

- Whenever it makes sense in terms of functionality, commit the changes.

- Using git tools (like iterative rebase), you can squash/fixup/reword commits.

- use squash if you'd like to join two commits, but want to keep both commit messages.

- use fixup if the message is the same, or if the 2nd one can be discarded.

The commit message shall always follow the pattern:

- ISSUE-1234 Commit description
Only one whitespace must separate the ticket # and the description - no hyphen, no comma.

- The message should always be in the present imperative tense.

- The first word needs to be the verb to describe what was done:

TICKET-1 Fix layout issue on main page / TICKET-2 Add unit tests to MyNewService

### Sending PRs
Once the development is finished and the code is ready - a Pull Request can be opened to master.

The PR message must follow a similar rule to the commit message: TICKET# Pull Request Description.

The message can be the same as the (or one of them) commit message, if meaningful enough.

After sending the PR, a Jenkins job will be created and started, based you the code sent, and Sonar will also run over the new code. The CI can fail, either by compilation errors or test failures.

Whenever the CI fails, the PR author must attend to and fix the failure. If Sonar identifies issues with the new code, those issues will be automatically posted on the PR, pointing the cause and the faulty code.

Reviewing PRs
When starting a PR review, you'd have to:

- Add a comment to the PR, with "Reviewing." as text.

- Add comments to the code where suitable.

- Smoke test the code

- Approve or request changes to the PR.

- When merging the PR, use the “Rebase and merge” button
