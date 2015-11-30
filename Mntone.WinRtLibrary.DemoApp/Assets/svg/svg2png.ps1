$inkscape = "C:\Program Files\Inkscape\inkscape.com"
$items = (Get-Content settings-uwp.json -Encoding UTF8 | ConvertFrom-Json)
foreach ($item in $items)
{
	for ($i = 0; $i -lt $item.size.length; ++$i)
	{
		$option = "-z"
		$width = "-w" + $item.size[$i][1]
		$export = "--export-png=" + ($item.output_filename -F $item.size[$i][0], $item.size[$i][1])
		& $inkscape $item.input_filename $option $width $export
	}
}