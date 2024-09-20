using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QuoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private static List<string> Quotes = new List<string>
        {
            "The best way to get started is to quit talking and begin doing.",
            "Don’t let yesterday take up too much of today.",
            "The pessimist sees difficulty in every opportunity. The optimist sees opportunity in every difficulty.",
            "The only way to do great work is to love what you do. – Steve Jobs",
            "In the end, we will remember not the words of our enemies, but the silence of our friends. – Martin Luther King Jr.",
            "Life is what happens when you're busy making other plans. – John Lennon",
            "The purpose of our lives is to be happy. – Dalai Lama",
            "Get busy living or get busy dying. – Stephen King",
            "You only live once, but if you do it right, once is enough. – Mae West",
            "To be yourself in a world that is constantly trying to make you something else is the greatest accomplishment. – Ralph Waldo Emerson",
            "The best way to predict your future is to create it. – Abraham Lincoln",
            "You miss 100% of the shots you don’t take. – Wayne Gretzky",
            "Life is really simple, but we insist on making it complicated. – Confucius",
            "Success is not final, failure is not fatal: It is the courage to continue that counts. – Winston Churchill",
            "The only limit to our realization of tomorrow will be our doubts of today. – Franklin D. Roosevelt",
            "What lies behind us and what lies before us are tiny matters compared to what lies within us. – Ralph Waldo Emerson",
            "Dream big and dare to fail. – Norman Vaughan",
            "Act as if what you do makes a difference. It does. – William James",
            "Success usually comes to those who are too busy to be looking for it. – Henry David Thoreau",
            "Don’t watch the clock; do what it does. Keep going. – Sam Levenson",
            "The future belongs to those who believe in the beauty of their dreams. – Eleanor Roosevelt",
            "You are never too old to set another goal or to dream a new dream. – C.S. Lewis",
            "If you want to lift yourself up, lift up someone else. – Booker T. Washington",
            "Change your thoughts and you change your world. – Norman Vincent Peale",
            "It does not matter how slowly you go as long as you do not stop. – Confucius",
            "Believe you can and you're halfway there. – Theodore Roosevelt",
            "What we think, we become. – Buddha",
            "Success is how high you bounce when you hit bottom. – George S. Patton",
            "Opportunities don't happen. You create them. – Chris Grosser",
            "If you can dream it, you can do it. – Walt Disney",
            "Everything you’ve ever wanted is on the other side of fear. – George Addair",
            "Limit your 'always' and your 'nevers'. – Amy Poehler",
            "Nothing in life is to be feared, it is only to be understood. – Marie Curie",
            "We can do anything we want to if we stick to it long enough. – Helen Keller",
            "What you get by achieving your goals is not as important as what you become by achieving your goals. – Zig Ziglar",
            "The only person you are destined to become is the person you decide to be. – Ralph Waldo Emerson",
            "Keep your face always toward the sunshine—and shadows will fall behind you. – Walt Whitman",
            "It is never too late to be what you might have been. – George Eliot",
            "Do what you can, with what you have, where you are. – Theodore Roosevelt",
            "Hardships often prepare ordinary people for an extraordinary destiny. – C.S. Lewis",
            "Keep your eyes on the stars, and your feet on the ground. – Theodore Roosevelt",
            "The best time to plant a tree was twenty years ago. The second best time is now. – Chinese Proverb",
            "Perfection is not attainable, but if we chase perfection, we can catch excellence. – Vince Lombardi",
            "You must be the change you wish to see in the world. – Mahatma Gandhi",
            "Failure is simply the opportunity to begin again, this time more intelligently. – Henry Ford",
            "The greatest glory in living lies not in never falling, but in rising every time we fall. – Nelson Mandela",
            "Happiness is not something ready-made. It comes from your own actions. – Dalai Lama",
            "To succeed in life, you need three things: a wishbone, a backbone, and a funny bone. – Reba McEntire",
            "What we fear doing most is usually what we most need to do. – Tim Ferriss",
            "It always seems impossible until it’s done. – Nelson Mandela",
            "The mind is everything. What you think you become. – Buddha",
            "If you want to achieve greatness stop asking for permission. – Anonymous",
            "Everything has beauty, but not everyone sees it. – Confucius",
            "Life is either a daring adventure or nothing at all. – Helen Keller",
            "Do not go where the path may lead, go instead where there is no path and leave a trail. – Ralph Waldo Emerson",
            "The only way to achieve the impossible is to believe it is possible. – Charles Kingsleigh",
            "A person who never made a mistake never tried anything new. – Albert Einstein",
            "Your time is limited, so don’t waste it living someone else’s life. – Steve Jobs",
            "You are braver than you believe, stronger than you seem, and smarter than you think. – A.A. Milne",
            "Live as if you were to die tomorrow. Learn as if you were to live forever. – Mahatma Gandhi",
            "The greatest wealth is to live content with little. – Plato",
            "Success is not the key to happiness. Happiness is the key to success. – Albert Schweitzer",
            "Don’t count the days, make the days count. – Muhammad Ali",
            "The only thing standing between you and your goal is the story you keep telling yourself. – Jordan Belfort",
            "Believe in yourself and all that you are. Know that there is something inside you that is greater than any obstacle. – Christian D. Larson",
            "The best revenge is massive success. – Frank Sinatra",
            "Dream as if you'll live forever. Live as if you'll die today. – James Dean",
            "You are enough just as you are. – Meghan Markle",
            "Strive not to be a success, but rather to be of value. – Albert Einstein",
            "Success is walking from failure to failure with no loss of enthusiasm. – Winston Churchill",
            "You can't use up creativity. The more you use, the more you have. – Maya Angelou",
            "If you want to live a happy life, tie it to a goal, not to people or things. – Albert Einstein",
            "To live is the rarest thing in the world. Most people exist, that is all. – Oscar Wilde",
            "Success is a journey, not a destination. – Arthur Ashe",
            "You don’t have to be great to start, but you have to start to be great. – Zig Ziglar",
            "I find that the harder I work, the more luck I seem to have. – Thomas Jefferson",
            "You must do the things you think you cannot do. – Eleanor Roosevelt",
            "There are no limits to what you can accomplish, except the limits you place on your own thinking. – Brian Tracy",
            "What we achieve inwardly will change outer reality. – Plutarch",
            "Life is either a daring adventure or nothing. – Helen Keller",
            "Your life does not get better by chance, it gets better by change. – Jim Rohn",
            "Life isn't about finding yourself. Life is about creating yourself. – George Bernard Shaw",
            "The journey of a thousand miles begins with one step. – Lao Tzu",
            "Success is the sum of small efforts, repeated day in and day out. – Robert Collier",
            "Every day may not be good, but there's something good in every day. – Alice Morse Earle",
            "It is never too late to be what you might have been. – George Eliot",
            "Success is how high you bounce when you hit bottom. – George S. Patton",
            "Life is not about waiting for the storm to pass but learning to dance in the rain. – Vivian Greene",
            "The best way to find yourself is to lose yourself in the service of others. – Mahatma Gandhi",
            // Add more quotes as needed
        };

        [HttpGet]
        public IActionResult GetQuote()
        {
            var random = new Random();
            int index = random.Next(Quotes.Count);
            return Ok(Quotes[index]);
        }
    }
}
