![BANNER(https://jukalang.com)](./docs/banner.png)
<hr>
<h1 align="center">📖 Table Of Contents</h1>

- [**What is JLDN?**](#about)
- - [**What is the purpose?**](#used-for)
- - [**How does our decentralized  network work?**](#how-our-decentralized-network-works)
- [**What is a `manifest.yaml` file?**](#manifest-file)
- - [**Manifest file format**](#manifest-format)
- [**Why are installed libraries encrypted?**](#encryption)
- [**What are the commands?**](#usage)
- - [**Install Package**](#install-usage)
- - [**Bump Version**](#bump-usage)
# About

## Used For
**JLDN** is a package manager created and maintained by the Juka Language organization. It allows users to create, publish, and use libraries. *For example* if you were creating a web server, instead of recreating the whole https protocal you can install a juka library that gives you a solid framework.

## How our decentralized  network works
Our decentralized network is how JLDN is able to recieve package data. This includes the libraries contents. We pull data straight from github making it easier, and faster to recieve packages. 

# Manifest File
The `manifest.yaml` file is used to give specifications about a package. This includes the current version, description, and content. 

## Manifest Format 
The manifest is formated as the following:
```yaml
version: 0.0.1
package_name: name
package_description: descr
library_directory: lib
main_repo_branch: main
repo_name: JLDN
repo_author_name: jukaLang
```

# Encryption 
We use a encrypted solution when you install packages from **JLDN**. Since Juka's primary target is runtime speed encryption is the fastest way of the Juka runtime to execute.

# Usage
## Install Usage
*Installs a package using the decentralized network*
```bash
jldn install {git_repo_author} {git_repo} {branch} { FLAGS }
```

Flags:
<br>`-nm` - Specifies that the repo does not contain a manifest file and you want to install anyways 
<br>`--force` - Forces to overwrite if package name already exists 

## Bump Usage 
*Reverts to goes to specified **JLDN** version*
```bash
jldn bump {service} {version}
```

Services:
	<br>**JLDN**<br>**Juka**
Flags:

**NO FLAGS WERE FOUND FOR THIS COMMAND**

# How to install
## Windows
To install on windows, all you have to do is simply install the `win_installer.exe` and run it and everything else will be automated! You can find that file in the release assests.

## Linux

**COMING SOON**
