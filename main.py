def Rectangle():
    print("?מה יהיה גובה המגדל")
    inHeight=input()
    if (isinstance(int(inHeight), int)):
        height=int(inHeight)
        print("?מה יהיה רוחב המגדל")
        inWidth=input()
        if (isinstance(int(inWidth), int)):
            width=int(inWidth)
            if height>=2:
                if height==width or abs(height-width>5):
                    print((height)*(width),":שטח מגדל המלבן הוא")
                else:
                    print((height)*2+(width)*2,":היקף מגדל המלבן הוא")
            else:
                print("גובה המגדל חייב להיות גדול או שווה ל2")
        else:
            print("רוחב המגדל לא תקין")
    else:
        print("גובה המגדל לא תקין")

def Triangle():
    print("?מה יהיה גובה המגדל")
    height=input()
    if (isinstance(int(height), int)):
        print("?מה יהיה רוחב המגדל")
        width=input()
        if (isinstance(int(width), int)):
            print(":בחר מאחת האפשרוויות הבאות")
            print("בחר 1 עבור חישוב היקף המגדל")
            print("בחר 2 עבור הדפסת המשולש")
            choice=input()
            width=int(width)
            height=int(height)
            if choice=="1":
                perimeter = height + (2 * ((width - 1) // 2))
                print("היקף המשולש הוא:", height + (2 * ((width - 1) // 2)))
            elif choice  == "2":
                if width % 2 == 0 or width > height * 2:
                    print("לא ניתן להדפיס את המשולש")
                else:
                    for i in range(1, height + 1):
                        stars="*"*(2*i+1)
                        spaces=" "*((width-len(stars))//2)
                        print(spaces+stars)
while True:
    print(":בחר מאחת האפשרוויות הבאות")
    print("בחר 1 עבור מגדל מלבן")
    print("בחר 2 עבור מגדל משולש")
    print("רוצה לצאת מהתוכנית? בחר 3")
    choice = input()

    if choice == "1":
        Rectangle()
    elif choice == "2":
        Triangle()
    elif choice == "3":
        break

    else:
        print("אנא הזן בחירה חוקית")