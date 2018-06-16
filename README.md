# XMLua-Transpiler
Transpiles XML to Lua

## Why on earth would you want to transpile XML to Lua!?
You don't. Trust me.

## How do I transpile XML to Lua?
Create a file named `config.xml` in `/XMLua Transpiler/bin/Debug/netcoreapp2.0`

Example config: 
```xml
<config>
    <src>src</src>
    <bin>bin</bin>
    <fileType>xmlua</fileType>
</config>
```

Create directories named `src` and `bin` in that same directory as the `.xml` file

Then build and run the solution, and it will watch and files in the `src` directory for changes, and transpile them.


## Example `.xmlua` file
```xml
<script>
	<variable name="x" value="10" />
	<function name="func">
		<parameters>
			<parameter>x</parameter>
		</parameters>
		<body>
			<call function="print">
				<argument>"hey " .. x</argument>
			</call>
			<if-statement>
				<if>
					<checks>
						<check operator="or" lefthand="x" comparator="==" righthand="5"/>
						<check operator="or" lefthand="x" comparator="==" righthand="y"/>
					</checks>
					<body>
						<call function="print">
							<argument>"hey it's a 5!"</argument>
						</call>
					</body>
				</if>
				<elseif>
					<checks>
						<check operator="or" lefthand="x" comparator="&lt;" righthand="5"/>
					</checks>
					<body>
						<call function="print">
							<argument>"hey it's lower than 5!"</argument>
						</call>
					</body>
				</elseif>
				<else>
					<body>
						<call function="print">
							<argument>"hey it's nothing I know!"</argument>
						</call>
					</body>
				</else>
			</if-statement>
			<for-loop variable="i" start="1" end="10" increments="1">
				<body>
					<call function="print">
						<argument>i</argument>
					</call>
				</body>
			</for-loop>
			<ipairs-loop key="key" value="value" variable="{1, 2, 3}">
				<body>
					<call function="print">
						<argument>key .. ":" .. value</argument>
					</call>
				</body>
			</ipairs-loop>
			<return value="'Return: ' .. x " />
		</body>
	</function>
	<call function="func">
		<argument>x</argument>
	</call>
	<call function="func">
		<argument>5</argument>
	</call>
	<call function="print">
		<argument>10</argument>
		<argument>15</argument>
	</call>
	<call function="print">
		<argument>
			<call function="func">
				<argument>5</argument>
			</call>
		</argument>
		<argument>
			<call function="func">
				<argument>10</argument>
			</call>
		</argument>
	</call>
</script>

```

## Transpiles to:
```lua
x = 10
function func(x)
	print("hey " .. x)
	if (x == 5 or x == y) then
		print("hey it's a 5!")
	elseif (x < 5) then
		print("hey it's lower than 5!")
	else
		print("hey it's nothing I know!")
	end
	for i = 1, 10, 1  do
		print(i)
	end
	for key,value in ipairs({1, 2, 3}) do
		print(key .. ":" .. value)
	end
	return 'Return: ' .. x 

end
func(x)
func(5)
print(10, 15)
print(
	func(5)
, 
	func(10)
)
```

