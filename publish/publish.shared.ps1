# Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
#
# Licensed under the ImageMagick License (the "License"); you may not use this file except in
# compliance with the License. You may obtain a copy of the License at
#
#   https://www.imagemagick.org/script/license.php
#
# Unless required by applicable law or agreed to in writing, software distributed under the
# License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
# either express or implied. See the License for the specific language governing permissions
# and limitations under the License.

. $PSScriptRoot\..\tools\windows\utils.ps1

function addFile($xml, $source, $target) {
    Write-Host "Adding '$source' as '$target'"

    $files = $xml.package.files

    $file = $xml.CreateElement("file", $xml.DocumentElement.NamespaceURI)

    $srcAtt = $xml.CreateAttribute("src")
    $srcAtt.Value = $source
    [void]$file.Attributes.Append($srcAtt)

    $targetAtt = $xml.CreateAttribute("target")
    $targetAtt.Value = $target
    [void]$file.Attributes.Append($targetAtt)

    [void]$files.AppendChild($file)
}

function addLibrary($xml, $library, $quantumName, $platform, $targetFramework) {
    $libraryName = $library
    if ($quantumName -ne "") {
        $libraryName = "$library-$quantumName-$platform"
    }

    $source = fullPath "src\$library\bin\Release$quantumName\$platform\$targetFramework\$libraryName.dll"
    $target = "lib\$targetFramework\$libraryName.dll"
    addFile $xml $source $target

    $source = fullPath "src\$library\bin\Release$quantumName\$platform\$targetFramework\$libraryName.xml"
    $target = "lib\$targetFramework\$libraryName.xml"
    addFile $xml $source $target
}

function loadAndInitNuSpec($package, $version, $commit) {
    $path = fullPath "publish\$package.nuspec"
    $xml = [xml](Get-Content $path)
    $xml.package.metadata.version = $version
    $xml.package.metadata.releaseNotes = "https://github.com/dlemstra/Magick.NET/releases/tag/$version"

    $namespaceManager = New-Object -TypeName "Xml.XmlNamespaceManager" -ArgumentList $xml.NameTable
    $namespaceManager.AddNamespace("nuspec", $xml.DocumentElement.NamespaceURI)
    $nodes = $xml.SelectNodes("//nuspec:dependency[not(@version)]", $namespaceManager)
    foreach ($node in $nodes) {
        $node.SetAttribute("version", $version);
    }

    $repository = $xml.SelectSingleNode("//nuspec:repository", $namespaceManager)
    $repository.SetAttribute("commit", $commit);

    return $xml
}

function createAndSignNuGetPackage($xml, $name, $version, $pfxPassword) {
    $nuspecFile = fullPath "publish\$name.nuspec"
    $xml.Save($nuspecFile)

    $nuget = fullPath "tools\windows\nuget.exe"
    & $nuget pack $nuspecFile -NoPackageAnalysis
    checkExitCode "Failed to create NuGet package"

    if ($pfxPassword.Length -gt 0) {
        $nupkgFile = fullPath "$name*.nupkg"
        $certificate = fullPath "build\windows\ImageMagick.pfx"
        & $nuget sign $nupkgFile -CertificatePath "$certificate" -CertificatePassword "$pfxPassword" -Timestamper http://sha256timestamp.ws.symantec.com/sha256/timestamp
        checkExitCode "Failed to sign NuGet package"
    }
}

function copyNuGetPackages($destination) {
    Remove-Item $destination -Recurse -ErrorAction Ignore
    [void](New-Item -ItemType directory -Path $destination)
    Copy-Item "*.nupkg" $destination
}