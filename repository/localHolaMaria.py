import pyttsx3
import speech_recognition as sr
import wikipedia

def talk(message):
    maria = pyttsx3.init()
    maria.setProperty('voice','spanish')
    maria.setProperty('rate', 150)
    maria.say(message)
    maria.runAndWait()

def hear():
    listener = sr.Recognizer()
    with sr.Microphone() as source:
        print('Speak Anything : ')
        audio = listener.listen(source)
        text = listener.recognize_google(audio)
        print('You said: {}'.format(text))
    return text

def wiki_research(data):
    wikipedia.set_lang("es")
    context = wikipedia.search(data, results=1, suggestion=False)
    print(wikipedia.summary(context)[:200])
    information = wikipedia.summary(context)[:200]
    return information

def main():
    #talk('Hi! My name is Maria, how can I help you?')
    #talk('Hola, dime un personaje')
    #txt = hear()
    #info = wiki_research(txt)
    #talk(info)
    talk('El número de mitocondrias por célula depende del tipo celular')

main()