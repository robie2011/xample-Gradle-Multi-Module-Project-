# Matplotlib

## Example

```python
import matplotlib.pyplot as plt
import numpy as np

t = np.arange(0,2.5,0.1)
y1 = np.sin(math.pi*t)
y2 = np.sin(math.pi*t+math.pi/2)
y3 = np.sin(math.pi*t-math.pi/2)

plt.plot(t,y1,'b--',t,y2,'g',t,y3,'r-.')


# using kwargs for setting chart properties
plt.plot([1,2,4,2,1,0,1,2,1,4],linewidth=2.0)


# using subplot
# .subplot([CountRows] [CountColumns] [SelectCell] )
t = np.arange(0,5,0.1)
y1 = np.sin(2*np.pi*t)
y2 = np.sin(2*np.pi*t)
plt.subplot(211)
plt.plot(t,y1,'b-.')
plt.subplot(212)
plt.plot(t,y2,'r--')


# labeling
plt.xlabel('Counting')
plt.ylabel('Square values')
plt.title('My first plot',fontsize=20,fontname='Times New Roman')

# setup axis
# [xmin, xmax, ymin, ymax]
plt.axis([0,5,0,20])

# rotating x-labels
plt.tick_params(axis='x', labelrotation=90)

# adding grid
plt.grid(True)

# legend (see options below)
plt.legend(['First series'])
# plt.legend(['First series','Second series','Third series'],loc=2)


# saving
plt.savefig('my_chart.png')
```



### Legend Options

| Location String | Location Code |
| --------------- | ------------- |
| 'best'          | 0             |
| 'upper right'   | 1             |
| 'upper left'    | 2             |
| 'lower left'    | 3             |
| 'lower right'   | 4             |
| 'right'         | 5             |
| 'center left'   | 6             |
| 'center right'  | 7             |
| 'lower center'  | 8             |
| 'upper center'  | 9             |
| 'center'        | 10            |



### Magic Commands

```python
# 171 is input line name (?)
%save my_first_chart 171

%load my_first_chart.py
%run my_first_chart.py
```

## Adding Texts

```python
plt.axis([0,5,0,20])
plt.title('My first plot',fontsize=20,fontname='Times New Roman') ...: plt.xlabel('Counting',color='gray')
plt.ylabel('Square values',color='gray')

# texts will be above of points
plt.text(1,1.5,'First')
plt.text(2,4.5,'Second')
plt.text(3,9.5,'Third')
plt.text(4,16.5,'Fourth')

# adding latex
plt.text(1.1,12,r'$y = x^2$',fontsize=20,bbox={'facecolor':'yellow', 'alpha':0.2})

plt.plot([1,2,3,4],[1,4,9,16],'ro')
```

## Handling Date on Label

```python
import datetime
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.dates as mdates

months = mdates.MonthLocator()
days = mdates.DayLocator()
timeFmt = mdates.DateFormatter('%Y-%m')

events = [datetime.date(2015,1,23),datetime.
          date(2015,1,28),datetime.date(2015,2,3),datetime.
          date(2015,2,21),datetime.date(2015,3,15),datetime.
          date(2015,3,24),datetime.date(2015,4,8),datetime.date(2015,4,24)]
readings = [12,22,25,20,18,15,17,14]

fig, ax = plt.subplots()
plt.plot(events,readings)
ax.xaxis.set_major_locator(months)
ax.xaxis.set_major_formatter(timeFmt)
ax.xaxis.set_minor_locator(days)
```

