---

# README: Configuring GitHub Copilot Instructions & Agents

This guide explains how to structure your local repository and global settings to customize GitHub Copilot behavior in Visual Studio 2026. Leveraging these configurations ensures code consistency, automates repetitive tasks, and tailors Copilot's contextual awareness to our project's specific architectural patterns.

---

## 📂 Configuration Architecture At-a-Glance

To implement custom behaviors, Copilot looks for specific files in your repository root and your global user profile.

```text
A. Repository-Level Settings
📁 Your-Repository-Root/
│
└── 📁 .github/
    └── copilot-instructions.md         		<-- 1. Custom Instructions
    │
    └── 📁 instructions/
    │   └── 📄 <name>.instructions.md  			<-- 2. Path-Specific Instructions
    │
    └── 📁 skills/
    │	└── 📁 <skill-name>/
    │       └── 📄 SKILL.md         			<-- 3. Agent Skills
    │
    └── 📁 agents/
    │   └── 📄 <agent-name>.agent.md    		<-- 4. Custom Agents
    │
    └── 📁 prompts/
        └── 📄 <prompt-name>.prompt.md    		<-- 5. Prompt Files
│
└── 📁 .agents/
    └── 📁 skills/
        └── 📁 <skill-name>/
            └── 📄 SKILL.md         			<-- 3. Agent Skills   # Method 2

B. Global Settings(apply to all repos):
📁 %USERPROFILE%/
│
└── copilot-instructions.md              		<-- 1. Custom Instructions
│
├── 📁 .copilot/
│   └── 📁 instructions/
│       └── 📄 <name>.instructions.md       	<-- 2. Path-Specific Instructions
│
└── 📁 .agents/
│   └── 📁 skills/
│		└── 📁 <skill-name>/
│           └── 📄 SKILL.md                 	<-- 3. Agent Skills
│						
└── 📁 .github/						
    └── 📁 agents/
        └── 📄 <agent-name>.agent.md    		<-- 4. Custom Agents

```


### File/Folder Structure for Local Repo

**1. Custom Instructions**

* `.github/copilot-instructions.md` *(Applies repository-wide to all chats and inline completions)*

    Use the `/generateInstructions` command to create the file

**2. Path-Specific Instructions**

* `.github/instructions/<name>.instructions.md` *(Targeted rules linked to specific directories, scopes, or projects)*

**3. Agent Skills**

* `.github/skills/<skill-name>/SKILL.md` *(Defines executable CLI tools, local scripts, or external API hooks the agent can leverage)*

**4. Custom Agents**

* `.github/agents/<agent-name>.agent.md` *(Markdown-based definition establishing the agent persona, specialized system prompts, and referenced skills)*

**5. Prompt Files**

* `.github/prompts/<prompt-name>.prompt.md` *(Reusable prompt files for Copilot Chat)  
  `/<prompt-name>` Loads a prompt file into the chat window for immediate use.  
  `/savePrompt <name>` Saves the current chat context as a new prompt file for future reuse.

---

### File/Folder Structure for Global Settings

**1. Custom Instructions**

* `%USERPROFILE%\.github\copilot-instructions.md` *(Fallback rules applied universally across all individual repositories opened by the user)*

**2. Path-Specific Instructions**

* `%USERPROFILE%\.github\instructions\<name>.instructions.md` *(Global defaults targeting universal sub-folder patterns, like standard test or mock directory formats)*

**3. Agent Skills**

* `%USERPROFILE%\.agent\skills\<skill-name>\SKILL.md` *(User-level tools available for execution across any repository workspace)*

**4. Custom Agents**

* `%USERPROFILE%\.github\agents\<agent-name>.agent.md` *(Global system-wide custom agents accessible via `@agentname` in the Visual Studio Chat window)*



---

> ⚠️ **Priority Rule:** Files explicitly declared in the **local repository** completely override or extend matching configuration scopes in the **global settings**. Local rules take precedence to maintain strict project-specific compliance.
> 
>

### Resources:
* https://github.com/github/awesome-copilot/
* https://github.com/dotnet/skills
* skills.sh
* github.com/agentskills/agentskills
* github.com/anthropics/skills/
* code.visualstudio.com/docs/copilot/customization/agent-skills
