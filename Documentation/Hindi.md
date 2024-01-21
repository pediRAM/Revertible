# वापस करने योग्य (Revertible)
प्रत्यावर्तनीय गुणों के साथ वर्गों को परिभाषित करने की सुविधा प्रदान करता है।

वापस करने योग्य
विशेषताएँ
उदाहरण
यह काम किस प्रकार करता है
राज्य आरेख/समयरेखा
यूएमएल क्लास आरेख
उदाहरण कोड
## विशेषताएँ
- [Revertible] विशेषता: किसी वर्ग में गुणों को रिवर्टिबल के रूप में चिह्नित करता है।
- SaveRevertibleProperties(): वापस करने योग्य संपत्तियों के वर्तमान मूल्यों को सहेजता है।
- RevertRevertibleProperties(): वापस करने योग्य गुणों को उनके सहेजे गए मानों (यदि कोई हो) में वापस कर देता है।
- hasModifiedRevertibleProperties (बूलियन): इंगित करता है कि क्या किसी वापस करने योग्य संपत्ति का मूल्य बदल दिया गया है।

## उदाहरण
उन परिदृश्यों के लिए आदर्श जहां आपको मॉडल या फ़ाइल में परिवर्तनों को सहेजे बिना, उपयोगकर्ता द्वारा संशोधित सेटिंग्स जैसे सभी परिवर्तित मानों को वापस लाने की आवश्यकता होती है।

## यह काम किस प्रकार करता है
### राज्य आरेख/समयरेखा
बेसरिवर्टिबल को विस्तारित करने वाले और [Revertible] के साथ एनोटेट किए गए गुणों को शामिल करने वाले प्रकार को इंस्टेंट करने के बाद, आप जरूरत पड़ने पर बाद में उन्हें वापस लाने के लिए रिवर्सिबल गुणों की वर्तमान स्थिति को सहेज सकते हैं।

जैसा कि नीचे दिए गए चित्र में दिखाया गया है, राज्य 5 पर, जब रिवर्ट विधि लागू की जाती है, तो मान राज्य 3 (टी2 == टी1) पर पहले से सहेजे गए मानों पर वापस आ जाते हैं/सेट हो जाते हैं।

**ध्यान दें:** [Revertible] एनोटेशन के बिना गुणों को हमेशा नजरअंदाज कर दिया जाता है।

![State Diagram](Timeline.drawio.png)

## यूएमएल क्लास आरेख
अपनी कक्षा को वापस करने योग्य बनाने के लिए, बस BaseRevertible का विस्तार करें और उन गुणों को एनोटेट करें जिन्हें आप [Revertible] विशेषता के साथ वापस करना चाहते हैं:

![UML Class Diagram](Klassendiagramm.png)

## उदाहरण कोड
यहां कक्षा को वापस करने योग्य बनाने का एक सरल उदाहरण दिया गया है:
```cs
using Revertible;

// कक्षा में [Revertible] असाइन करना वैकल्पिक है,
// जब तक आपको कक्षा के बाहर IRevertible तरीकों तक पहुंचने की आवश्यकता न हो।
[Revertible]
public class RevertibleClass : BaseRevertible
{
     // बस उन संपत्तियों को [Revertible] असाइन करें जिन्हें आप सहेजना और वापस करना चाहते हैं।
    [Revertible]
    public bool Enabled { get; set; }

    [Revertible]
    public int ID { get; set; }

    [Revertible]
    public string Name { get; set; }

    [Revertible]
    public object SomeObject { get; set; }

     //[Revertible] के बिना गुणों को नजरअंदाज कर दिया जाता है
    public double NonRevertibleDoubleProperty { get; set; }
    public char NonRevertibleCharProperty { get; set; }
}

/*** मान सहेजें और वापस लाएँ ***/
//
private RevertibleClass _revertibleField = new RevertibleClass();

private void SomeMethod()
{
    _revertibleField.Enabled = true;
    _revertibleField.Name = "John Doe";


     // वापस करने योग्य संपत्तियों की वर्तमान स्थिति सहेजें:
     _revertibleField.SaveRevertibleProperties();

     // कुछ अन्य कोड...
     _revertibleField.Enabled = false;
    _revertibleField.Name = "Something else!";

     // वापस करने योग्य गुणों के मान वापस लाएं:
     _revertibleField.RevertRevertibleProperties();
     // अब: Enabled == true और Name == "John Doe".
}
```
