import { motion } from "motion/react";
import { Book, Headphones, ShoppingCart } from "lucide-react";

const features = [
  {
    icon: <Book className="w-6 h-6 text-gray-600" />,
    title: "Browse Books",
    description: "Explore a wide range of genres and authors.",
  },
  {
    icon: <Headphones className="w-6 h-6 text-gray-600" />,
    title: "Listen to Audiobooks",
    description: "Stream or download your favorite audiobooks.",
  },
  {
    icon: <ShoppingCart className="w-6 h-6 text-gray-600" />,
    title: "Easy System",
    description: "Seamless and secure experience.",
  },
];

function Home() {

  console.log("🧪 VITE_API_URL:", import.meta.env.VITE_API_URL);
  
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100 px-4">
      <motion.h1
        initial={{ y: 40, opacity: 0 }}
        animate={{ y: 0, opacity: 1 }}
        transition={{ duration: 0.8, ease: "easeOut" }}
        className="text-4xl font-bold mb-4 text-gray-800"
      >
        Welcome to the Kay's Bookstore
      </motion.h1>

      <motion.p
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ delay: 0.4, duration: 0.6 }}
        className="text-lg mb-8 text-gray-600 text-center"
      >
        Explore our collection of books and audiobooks.
      </motion.p>

      <div className="grid grid-cols-1 sm:grid-cols-3 gap-6 w-full max-w-4xl">
        {features.map((feat, i) => (
          <motion.div
            key={i}
            initial={{ scale: 0.95, opacity: 0 }}
            animate={{ scale: 1, opacity: 1 }}
            transition={{ delay: 0.6 + i * 0.2, duration: 0.4 }}
            className="bg-white/70 backdrop-blur-sm p-6 rounded-2xl shadow-sm border border-gray-200 flex flex-col items-center text-center hover:shadow-md transition-shadow"
          >
            {feat.icon}
            <h2 className="mt-3 text-xl font-semibold text-gray-800">{feat.title}</h2>
            <p className="text-gray-500 mt-1">{feat.description}</p>
          </motion.div>
        ))}
      </div>
    </div>
  );
}

export default Home;
